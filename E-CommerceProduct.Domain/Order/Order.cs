using E_CommerceProduct.Domain.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Domain.Order
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        // Navigation property to order items
        public List<OrderProduct> OrderItems { get; set; }
    }
}
