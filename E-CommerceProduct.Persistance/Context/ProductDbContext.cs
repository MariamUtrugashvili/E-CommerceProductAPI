using Microsoft.EntityFrameworkCore;

namespace E_CommerceProduct.Persistance.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    }
}
