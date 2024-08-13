using E_CommerceProduct.Domain.Enums;

namespace E_CommerceProduct.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public CategoryName Name { get; set; }

        // Navigation property
        public List<Product> Products { get; set; }
    }
}

