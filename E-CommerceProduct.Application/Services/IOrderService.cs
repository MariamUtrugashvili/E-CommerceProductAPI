using E_CommerceProduct.Application.Orders.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Application.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderRequestModel request, CancellationToken cancellationToken);
    }
}
