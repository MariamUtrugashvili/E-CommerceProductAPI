namespace E_CommerceProduct.Application.ProductQuantities.Request
{
    public class ProductQuantitiesPutModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
