using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Domain.OrderProduct
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }

        // Navigation properties
        public Order.Order Order { get; set; }
        public Product.Product Product { get; set; }
    }
}
