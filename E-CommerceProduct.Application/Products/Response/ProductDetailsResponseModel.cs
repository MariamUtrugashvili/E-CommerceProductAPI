using E_CommerceProduct.Domain.Enums;

namespace E_CommerceProduct.Application.Products.Response
{
    public class ProductDetailsResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public List<CategoryName> CategoryNames { get; set; }
    }
}
