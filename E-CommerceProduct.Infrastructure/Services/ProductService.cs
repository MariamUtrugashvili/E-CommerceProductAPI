using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Exceptions;
using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Application.Products.Request;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Enums;
using E_CommerceProduct.Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceProduct.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductRepository.GetAllProductAsync(cancellationToken);
            return result.Adapt<IEnumerable<ProductResponseModel>>();

        }

        public async Task<ProductResponseModel> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductRepository.GetProductAsync(cancellationToken, id);
            if (result == null)
                throw new ItemNotFoundException("Product with this Id wasn't found");
            return result.Adapt<ProductResponseModel>();
        }

        public async Task CreateProductAsync(CreateProductRequestModel product, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.AnyAsync(x => x.Name == product.Name, cancellationToken))
                throw new AlreadyExistsException("Product with this Name already exists");

            // Initialize a list to store category IDs
            var categoryIds = new List<Guid>();

            // Loop through the provided category names
            foreach (var categoryName in product.CategoryNames)
            {
                // Retrieve the category ID for each name
                var categoryId = await _unitOfWork.CategoryRepository
                    .GetPropertyAsync(
                        x => x.Name == categoryName, // Predicate to match the category name
                        x => x.Id, // Selector to return the category ID
                        cancellationToken
                    );

                if (categoryId == Guid.Empty)
                    throw new ItemNotFoundException($"Category '{categoryName}' was not found");

                // Add the category ID to the list
                categoryIds.Add(categoryId);
            }

            // Adapt the product model
            var result = product.Adapt<Product>();
            result.Id = Guid.NewGuid();
            result.CreatedAt = DateTime.Now;

            // Save the product
            await _unitOfWork.ProductRepository.AddAsync(result, cancellationToken);

            // Add ProductQuantity
            var productQuantityToInsert = new ProductQuantity
            {
                Id = Guid.NewGuid(),
                ProductId = result.Id,
                Quantity = product.Quantity,
            };
            await _unitOfWork.ProductQuantityRepository.AddAsync(productQuantityToInsert, cancellationToken);

            // Insert into ProductCategory for each category ID
            foreach (var categoryId in categoryIds)
            {
                var productCategoryToInsert = new ProductCategory
                {
                    Id = Guid.NewGuid(),
                    ProductId = result.Id,
                    CategoryId = categoryId
                };
                await _unitOfWork.ProductCategoryRepository.AddAsync(productCategoryToInsert, cancellationToken);
            }

            // Save changes
            await _unitOfWork.SaveAsync();
        }


        public async Task UpdateProductAsync(UpdateProductRequestModel product, Guid id, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork.ProductRepository.GetAsync(cancellationToken, id);

            if (entity == null)
                throw new ItemNotFoundException("Product with this Id wasn't found");

            entity.Name = product.Name;
            entity.ImageUrl = product.ImageUrl;
            entity.Price = product.Price;
            entity.UpdatedAt = DateTime.Now;

            _unitOfWork.ProductRepository.Update(entity, cancellationToken);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(cancellationToken, id);
            if (product == null) throw new ItemNotFoundException("Product not found");

            _unitOfWork.ProductRepository.Delete(product, cancellationToken);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ProductDetailsResponseModel>> GetProductDetailsAsync(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductRepository.GetAllProductDetailsAsync(cancellationToken);

            return result;
        }
    }
}
