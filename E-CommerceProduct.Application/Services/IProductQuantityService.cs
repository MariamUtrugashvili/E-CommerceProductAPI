using E_CommerceProduct.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Services
{
    public interface IProductQuantityService
    {
        Task<IEnumerable<ProductQuantity>> GetAllProductQuantitiesAsync(CancellationToken cancellationToken);
        Task<ProductQuantity> GetProductQuantityByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ProductQuantity> CreateProductQuantityAsync(ProductQuantity productQuantity, CancellationToken cancellationToken);
        Task UpdateProductQuantityAsync(ProductQuantity productQuantity, CancellationToken cancellationToken);
        Task DeleteProductQuantityAsync(Guid id, CancellationToken cancellationToken);
    }
}
