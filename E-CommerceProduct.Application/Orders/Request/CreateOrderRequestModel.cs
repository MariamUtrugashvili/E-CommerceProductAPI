using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Orders.Request
{
    public class CreateOrderRequestModel
    {
        public List<OrderProductRequestModel> OrderItems { get; set; }
    }
}
