﻿using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Domain.Models;
using E_CommerceProduct.Infrastructure.Common;
using E_CommerceProduct.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Infrastructure.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ProductDbContext context) : base(context) { }

        public Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

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

        public Task UpdateProductAsync(ProductCategoriesRequestModel product, Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
