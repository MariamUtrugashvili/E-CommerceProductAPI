using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Infrastructure.Services
{
    public class ProductQuantityService : IProductQuantityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductQuantityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductQuantity>> GetAllProductQuantitiesAsync(CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductQuantityRepository.GetAllAsync(cancellationToken);
        }

        public async Task<ProductQuantity> GetProductQuantityByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductQuantityRepository.GetAsync(cancellationToken, id);
        }

        public async Task<ProductQuantity> CreateProductQuantityAsync(ProductQuantity productQuantity, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProductQuantityRepository.AddAsync(productQuantity, cancellationToken);
            await _unitOfWork.SaveAsync();
            return productQuantity;
        }

        public async Task UpdateProductQuantityAsync(ProductQuantity productQuantity, CancellationToken cancellationToken)
        {
            _unitOfWork.ProductQuantityRepository.Update(productQuantity, cancellationToken);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductQuantityAsync(Guid id, CancellationToken cancellationToken)
        {
            var productQuantity = await _unitOfWork.ProductQuantityRepository.GetAsync(cancellationToken, id);
            if (productQuantity == null) throw new Exception("Product Quantity not found");

            _unitOfWork.ProductQuantityRepository.Delete(productQuantity, cancellationToken);
            await _unitOfWork.SaveAsync();
        }
    }
}
