﻿using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Domain.Models;

namespace E_CommerceProduct.Application.Repositories
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory> 
    {
        Task<IEnumerable<ProductCategoriesResponseModel>> GetProductCategoriesAsync(Guid productId, CancellationToken cancellationToken);
    }
}
