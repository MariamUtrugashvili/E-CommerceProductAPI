using E_CommerceProduct.Application.Categories.Response;
using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Exceptions;
using E_CommerceProduct.Application.Products.Request;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return result.Adapt<ProductResponseModel>();
        }

        public async Task CreateProductAsync(CreateProductRequestModel product, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.AnyAsync(x => x.Name == product.Name, cancellationToken))
                throw new AlreadyExistsException("Product with this Name already exist");

            if (!await _unitOfWork.CategoryRepository.AnyAsync(x => x.Name == product.CategoryName, cancellationToken))
                throw new ItemNotFoundException("This Category was not found");

            var categoryId = await _unitOfWork.CategoryRepository.GetAsync(cancellationToken,product.Name);

            var result = product.Adapt<Product>();
            result.Id = Guid.NewGuid();
            result.CreatedAt = DateTime.Now;

            await _unitOfWork.ProductRepository.AddAsync(result, cancellationToken);

            var productQuantityToInsert = new ProductQuantity
            {
                Id = new Guid(),
                ProductId = result.Id,
                Quantity = product.Quantity,
            };

            await _unitOfWork.ProductQuantityRepository.AddAsync(productQuantityToInsert, cancellationToken);

            await _unitOfWork.SaveAsync();
    
        }

        public async Task UpdateProductAsync(UpdateProductRequestModel product, Guid id, CancellationToken cancellationToken)
        {

            if (!await _unitOfWork.ProductRepository.AnyAsync(x => x.Id == id, cancellationToken))
                throw new ItemNotFoundException("Product with this Id wasn't found");

            var entity = product.Adapt<Product>();
            entity.Id = id;
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
            if (product == null) throw new Exception("Product not found");

            _unitOfWork.ProductRepository.Delete(product, cancellationToken);
            await _unitOfWork.SaveAsync();
        }
    }
}
