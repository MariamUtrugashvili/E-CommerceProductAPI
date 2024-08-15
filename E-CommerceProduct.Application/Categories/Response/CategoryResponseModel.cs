using E_CommerceProduct.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Categories.Response
{
    public class CategoryResponseModel
    {
        public Guid Id { get; set; }
        public CategoryName Name { get; set; }
    }
}
