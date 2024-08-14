namespace E_CommerceProduct.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public List<Category> Categories { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public ProductQuantity ProductQuantity { get; set; }
    }
}
