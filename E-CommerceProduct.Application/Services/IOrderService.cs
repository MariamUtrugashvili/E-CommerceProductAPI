using E_CommerceProduct.Application.Orders.Request;

namespace E_CommerceProduct.Application.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderRequestModel request, CancellationToken cancellationToken);
    }
}
