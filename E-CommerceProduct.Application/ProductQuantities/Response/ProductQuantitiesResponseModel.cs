namespace E_CommerceProduct.Application.ProductQuantities.Response
{
    public class ProductQuantitiesResponseModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
