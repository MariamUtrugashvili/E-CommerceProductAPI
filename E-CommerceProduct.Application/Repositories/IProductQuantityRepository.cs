using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.ProductQuantities.Response;
using E_CommerceProduct.Domain.Models;

namespace E_CommerceProduct.Application.Repositories
{
    public interface IProductQuantityRepository : IBaseRepository<ProductQuantity> 
    {
        Task<IEnumerable<ProductQuantitiesResponseModel>> GetAllProductQuantityAsync(CancellationToken cancellationToken);
    }
}
