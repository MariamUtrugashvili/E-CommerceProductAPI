namespace E_CommerceProduct.Application.Products.Request
{
    public class CreateProductRequestModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public List<string> CategoryNames { get; set; }
    }
}
