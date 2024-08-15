using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Application.Products.Request;
using E_CommerceProduct.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Repositories
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory> 
    {
        Task<IEnumerable<ProductCategoriesResponseModel>> GetProductCategoriesAsync(Guid productId, CancellationToken cancellationToken);
        Task UpdateProductAsync(ProductCategoriesRequestModel product, Guid id, CancellationToken cancellationToken);
        Task DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    }
}
