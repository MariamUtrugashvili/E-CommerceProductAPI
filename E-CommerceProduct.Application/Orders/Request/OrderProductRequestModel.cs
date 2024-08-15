using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Orders.Request
{
    public class OrderProductRequestModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
