using E_CommerceProduct.Application.Orders.Request;
using E_CommerceProduct.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestModel request, CancellationToken cancellationToken)
        {
            await _orderService.CreateOrderAsync(request, cancellationToken);
            return Ok(new { Message = "Order created successfully." });
        }
    }
}
