using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoriesResponseModel>> GetProductCategoriesAsync(Guid productId, CancellationToken cancellationToken);
        Task UpdateProductCategoryAsync(UpdateProductCategoryRequest request, Guid id, CancellationToken cancellationToken);
        Task DeleteProductCategoryAsync(Guid id, CancellationToken cancellationToken);
    }
}
