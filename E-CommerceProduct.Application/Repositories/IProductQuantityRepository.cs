using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.ProductQuantities.Response;
using E_CommerceProduct.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Repositories
{
    public interface IProductQuantityRepository : IBaseRepository<ProductQuantity> 
    {
        Task<IEnumerable<ProductQuantitiesResponseModel>> GetAllProductQuantityAsync(CancellationToken cancellationToken);
    }
}
