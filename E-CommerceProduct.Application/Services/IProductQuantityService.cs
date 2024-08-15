using E_CommerceProduct.Application.ProductQuantities.Request;
using E_CommerceProduct.Application.ProductQuantities.Response;

namespace E_CommerceProduct.Application.Services
{
    public interface IProductQuantityService
    {
        Task<IEnumerable<ProductQuantitiesResponseModel>> GetProductQuantity(CancellationToken cancellationToken);
        Task UpdateProductQuantityAsync(ProductQuantitiesPutModel productQuantity, Guid id, CancellationToken cancellationToken);
    }
}
