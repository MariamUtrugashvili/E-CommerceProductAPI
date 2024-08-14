﻿using E_CommerceProduct.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Products.Request
{
    public class UpdateProductRequestModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public CategoryName CategoryName { get; set; }
    }
}
