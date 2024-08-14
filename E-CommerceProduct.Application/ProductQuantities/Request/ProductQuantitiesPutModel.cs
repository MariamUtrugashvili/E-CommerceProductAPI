using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.ProductQuantities.Request
{
    public class ProductQuantitiesPutModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
