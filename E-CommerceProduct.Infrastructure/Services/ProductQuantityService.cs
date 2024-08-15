using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Exceptions;
using E_CommerceProduct.Application.ProductQuantities.Request;
using E_CommerceProduct.Application.ProductQuantities.Response;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ProductQuantitiesResponseModel>> GetProductQuantity(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductQuantityRepository.GetAllProductQuantityAsync(cancellationToken);
            return result.Adapt<IEnumerable<ProductQuantitiesResponseModel>>();
        }

        public async Task UpdateProductQuantityAsync(ProductQuantitiesPutModel productQuantity,Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ProductQuantityRepository.GetAsync(cancellationToken, id);

            if (entity == null)
                throw new ItemNotFoundException("ProductQuantity with this Id wasn't found");

            entity.ProductId = productQuantity.ProductId;
            entity.Quantity = productQuantity.Quantity;
            entity.UpdatedAt = DateTime.Now;

            _unitOfWork.ProductQuantityRepository.Update(entity, cancellationToken);
            await _unitOfWork.SaveAsync();
        }
    }
}
