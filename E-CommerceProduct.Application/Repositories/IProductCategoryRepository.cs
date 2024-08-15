using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Domain.Models;

namespace E_CommerceProduct.Application.Repositories
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory> 
    {
        Task<IEnumerable<ProductCategoriesResponseModel>> GetProductCategoriesAsync(Guid productId, CancellationToken cancellationToken);
        Task UpdateProductAsync(ProductCategoriesRequestModel product, Guid id, CancellationToken cancellationToken);
        Task DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    }
}
