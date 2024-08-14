using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Domain.Models;
using E_CommerceProduct.Infrastructure.Common;
using E_CommerceProduct.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext context) : base(context) { }
    }
}
