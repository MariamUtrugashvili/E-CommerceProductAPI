using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Domain.Models;
using E_CommerceProduct.Infrastructure.Common;
using E_CommerceProduct.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceProduct.Infrastructure.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<ProductCategoriesResponseModel>> GetProductCategoriesAsync(Guid productId, CancellationToken cancellationToken)
        {
            var productCategories = await _context.ProductCategory
                    .Where(pc => pc.ProductId == productId)
                    .Include(pc => pc.Category)
                    .Select(pc => new ProductCategoriesResponseModel
                    {
                        Id = pc.Id, 
                        ProductName = pc.Product.Name, 
                        CategoryNames = new List<string> { pc.Category.Name.ToString() }
                    })
                    .ToListAsync(cancellationToken);



            return productCategories;
        }
    }
}
