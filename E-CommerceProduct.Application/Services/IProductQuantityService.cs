using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Application.ProductQuantities.Request;
using E_CommerceProduct.Application.ProductQuantities.Response;
using E_CommerceProduct.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Services
{
    public interface IProductQuantityService
    {
        Task<IEnumerable<ProductQuantitiesResponseModel>> GetProductQuantity(CancellationToken cancellationToken);
        Task UpdateProductQuantityAsync(ProductQuantitiesPutModel productQuantity, Guid id, CancellationToken cancellationToken);
    }
}
