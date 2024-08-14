using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.ProductCategories.Request
{
    public class ProductCategoriesRequestModel
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
