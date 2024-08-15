namespace E_CommerceProduct.Domain.Models
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
