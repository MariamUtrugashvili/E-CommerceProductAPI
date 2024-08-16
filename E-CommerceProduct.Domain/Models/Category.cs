namespace E_CommerceProduct.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public List<ProductCategory> ProductCategories { get; set; }
    }
}

