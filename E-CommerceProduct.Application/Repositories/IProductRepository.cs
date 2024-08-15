using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Domain.Models;

namespace E_CommerceProduct.Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product> 
    {
        Task<ProductResponseModel> GetProductAsync(CancellationToken token, Guid id);
        Task<List<ProductResponseModel>> GetAllProductAsync(CancellationToken token);
        Task<IEnumerable<ProductDetailsResponseModel>> GetAllProductDetailsAsync(CancellationToken token);

    }
}
