using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;

namespace E_CommerceProduct.Application.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoriesResponseModel>> GetProductCategoriesAsync(Guid productId, CancellationToken cancellationToken);
        Task UpdateProductCategoryAsync(UpdateProductCategoryRequest request, Guid id, CancellationToken cancellationToken);
        Task DeleteProductCategoryAsync(Guid id, CancellationToken cancellationToken);
    }
}
