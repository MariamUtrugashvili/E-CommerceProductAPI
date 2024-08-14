using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Domain.Models;
using E_CommerceProduct.Infrastructure.Common;
using E_CommerceProduct.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context) { }

        public async Task<List<ProductResponseModel>> GetAllProductAsync(CancellationToken token)
        {
            var products = await _context.Products
         .Include(x => x.ProductQuantity)
         .Select(x => new ProductResponseModel
         {
             Id = x.Id,
             Name = x.Name,
             Price = x.Price,
             Quantity = x.ProductQuantity.Quantity
         }).ToListAsync(token);

            return products;
        }

        public Task<ProductResponseModel> GetProductAsync(CancellationToken token, params object[] key)
        {
            throw new NotImplementedException();
        }
    }
}
