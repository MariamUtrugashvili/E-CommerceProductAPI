using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Domain.Models;
using E_CommerceProduct.Infrastructure.Common;
using E_CommerceProduct.Persistance.Context;

namespace E_CommerceProduct.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ProductDbContext context) : base(context) { }
    }
}
