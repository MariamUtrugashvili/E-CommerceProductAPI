using E_CommerceProduct.Domain.Product;

namespace E_CommerceProduct.Domain.ProductQuantity
{
    public class ProductQuantity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Navigation property
        public Product.Product Product { get; set; }
    }
}
