namespace E_CommerceProduct.Application.Orders.Request
{
    public class CreateOrderRequestModel
    {
        public List<OrderProductRequestModel> OrderItems { get; set; }
    }
}
