using E_CommerceProduct.Application.Categories.Request;
using E_CommerceProduct.Application.Categories.Response;
namespace E_CommerceProduct.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseModel>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryResponseModel> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateCategoryAsync(CategoryRequestModel category, CancellationToken cancellationToken);
        Task UpdateCategoryAsync(CategoryRequestModel category, Guid id, CancellationToken cancellationToken);
        Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    }
}
