namespace E_CommerceProduct.Application.ProductCategories.Response
{
    public class ProductCategoriesResponseModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public List<string> CategoryNames { get; set; }
    }
}
