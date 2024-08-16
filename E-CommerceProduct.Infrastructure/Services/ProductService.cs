using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Exceptions;
using E_CommerceProduct.Application.Products.Request;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;
using Mapster;

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

        public async Task CreateProductAsync(CreateProductRequestModel product, CancellationToken cancellationToken)
        {
            await ValidateProductName(product.Name, cancellationToken);

            var categoryIds = await ValidateAndGetCategoryIdsAsync(product.CategoryNames, cancellationToken);

            var newProduct = CreateProductEntity(product);

            await SaveProductAsync(newProduct, product.Quantity, categoryIds, cancellationToken);
        }

        private async Task ValidateProductName(string productName, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.AnyAsync(x => x.Name == productName, cancellationToken))
                throw new AlreadyExistsException("Product with this Name already exists");
        }

        private async Task<List<Guid>> ValidateAndGetCategoryIdsAsync(IEnumerable<string> categoryNames, CancellationToken cancellationToken)
        {
            var allCategories = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
            var categoryIds = new List<Guid>();

            foreach (var categoryName in categoryNames)
            {
                var category = allCategories.FirstOrDefault(x => x.Name.ToString() == categoryName);

                if (category == null)
                    throw new ItemNotFoundException($"Category '{categoryName}' was not found");

                categoryIds.Add(category.Id);
            }

            return categoryIds;
        }

        private Product CreateProductEntity(CreateProductRequestModel product)
        {
            var result = product.Adapt<Product>();
            result.Id = Guid.NewGuid();
            result.CreatedAt = DateTime.Now;

            return result;
        }

        private async Task SaveProductAsync(Product product, int quantity, List<Guid> categoryIds, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProductRepository.AddAsync(product, cancellationToken);

            var productQuantity = new ProductQuantity
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Quantity = quantity,
            };
            await _unitOfWork.ProductQuantityRepository.AddAsync(productQuantity, cancellationToken);

            foreach (var categoryId in categoryIds)
            {
                var productCategory = new ProductCategory
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    CategoryId = categoryId
                };
                await _unitOfWork.ProductCategoryRepository.AddAsync(productCategory, cancellationToken);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
