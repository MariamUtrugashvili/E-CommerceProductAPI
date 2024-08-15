using E_CommerceProduct.Application.ProductQuantities.Response;
using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Domain.Models;
using E_CommerceProduct.Infrastructure.Common;
using E_CommerceProduct.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceProduct.Infrastructure.Repositories
{
    public class ProductQuantityRepository : BaseRepository<ProductQuantity>, IProductQuantityRepository
    {
        public ProductQuantityRepository(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<ProductQuantitiesResponseModel>> GetAllProductQuantityAsync(CancellationToken cancellationToken)
        {
            var productQuantities = await _context.ProductQuantities
                                   .Include(pq => pq.Product)
                                     .Select(pq => new ProductQuantitiesResponseModel
                                     {
                                         Id = pq.Id, 
                                         ProductId = pq.Product.Id,
                                         Name = pq.Product.Name, 
                                         Quantity = pq.Quantity 
                                     })
                                     .ToListAsync(cancellationToken);

            return productQuantities;
        }
    }
}
