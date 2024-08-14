namespace E_CommerceProduct.Domain.Models
{
    public class ProductQuantity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? UpdatedAt { get; set; }


        // Navigation property
        public Product Product { get; set; }
    }
}
