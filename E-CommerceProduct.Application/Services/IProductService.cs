using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Application.Products.Request;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<ProductDetailsResponseModel>> GetProductDetailsAsync(CancellationToken cancellationToken);
        Task<ProductResponseModel> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateProductAsync(CreateProductRequestModel product, CancellationToken cancellationToken);
        Task UpdateProductAsync(UpdateProductRequestModel product, Guid id, CancellationToken cancellationToken);
        Task DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    }
}
