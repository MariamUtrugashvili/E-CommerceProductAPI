using E_CommerceProduct.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.ProductCategories.Request
{
    public class UpdateProductCategoryRequest
    {
        public CategoryName NewCategory { get; set; }
    }
}
