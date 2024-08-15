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
        public async Task<IEnumerable<ProductDetailsResponseModel>> GetAllProductDetailsAsync(CancellationToken token)
        {
            var products = await _context.Products
                .Include(x => x.ProductQuantity)
                .Include(x => x.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Select(x => new ProductDetailsResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.ProductQuantity.Quantity,
                    ImageUrl = x.ImageUrl,
                    CategoryNames = x.ProductCategories.Select(pc => pc.Category.Name).ToList()
                })
                .ToListAsync(token);

            return products;
        }


        public async Task<ProductResponseModel> GetProductAsync(CancellationToken token, Guid id)
        {
            var product = await _context.Products
                      .Include(x => x.ProductQuantity)
                      .Where(x => x.Id == id)
                       .Select(x => new ProductResponseModel
                       {
                           Id = x.Id,
                           Name = x.Name,
                           Price = x.Price,
                           Quantity = x.ProductQuantity.Quantity
                       })
                       .SingleOrDefaultAsync(token);

            return product;
        }
    }
}
