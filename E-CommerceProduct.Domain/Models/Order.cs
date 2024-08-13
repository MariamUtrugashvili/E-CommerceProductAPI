namespace E_CommerceProduct.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        // Navigation property to order items
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
