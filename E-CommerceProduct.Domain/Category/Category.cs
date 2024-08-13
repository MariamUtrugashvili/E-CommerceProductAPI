using E_CommerceProduct.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Domain.Category
{
    public class Category
    {
        public Guid Id { get; set; }
        public CategoryName Name { get; set; }



        // Navigation property
        public List<Product.Product> Products { get; set; }
    }
}

