using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Orders.Request;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;

namespace E_CommerceProduct.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrderAsync(CreateOrderRequestModel request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(cancellationToken);
            var productQuantities = await _unitOfWork.ProductQuantityRepository.GetAllAsync(cancellationToken);

            var normalizedProducts = NormalizeProducts(products);
            var productQuantitiesMap = MapProductQuantities(productQuantities);

            var orderId = Guid.NewGuid();
            var orderProducts = new List<OrderProduct>();

            foreach (var item in request.OrderItems)
            {
                var product = GetProductByName(normalizedProducts, item.ProductName);
                var productQuantity = GetProductQuantity(productQuantitiesMap, product);

                ValidateProductAvailability(product, productQuantity, item.Quantity);

                var orderProduct = CreateOrderProduct(orderId, product, item.Quantity);
                orderProducts.Add(orderProduct);

                UpdateProductQuantity(productQuantity, item.Quantity);
            }

            var order = CreateOrder(orderId, orderProducts, products);
            await SaveOrderAsync(order, cancellationToken);
        }

        private Dictionary<string, Product> NormalizeProducts(IEnumerable<Product> products)
        {
            return products.ToDictionary(p => p.Name.Trim().ToLowerInvariant(), p => p);
        }

        private Dictionary<Guid, ProductQuantity> MapProductQuantities(IEnumerable<ProductQuantity> productQuantities)
        {
            return productQuantities.ToDictionary(pq => pq.ProductId, pq => pq);
        }

        private Product GetProductByName(Dictionary<string, Product> normalizedProducts, string productName)
        {
            var normalizedProductName = productName.Trim().ToLowerInvariant();
            if (!normalizedProducts.TryGetValue(normalizedProductName, out var product))
            {
                throw new InvalidOperationException($"Product with name '{productName}' does not exist.");
            }
            return product;
        }

        private ProductQuantity GetProductQuantity(Dictionary<Guid, ProductQuantity> productQuantitiesMap, Product product)
        {
            if (!productQuantitiesMap.TryGetValue(product.Id, out var productQuantity) || productQuantity == null)
            {
                throw new InvalidOperationException($"Product with name '{product.Name}' is not available.");
            }
            return productQuantity;
        }

        private void ValidateProductAvailability(Product product, ProductQuantity productQuantity, int requestedQuantity)
        {
            if (requestedQuantity > productQuantity.Quantity)
            {
                throw new InvalidOperationException($"Insufficient quantity for product with name '{product.Name}'. Available quantity: {productQuantity.Quantity}");
            }
        }

        private OrderProduct CreateOrderProduct(Guid orderId, Product product, int quantity)
        {
            return new OrderProduct
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = product.Id,
                ProductQuantity = quantity
            };
        }

        private void UpdateProductQuantity(ProductQuantity productQuantity, int quantity)
        {
            productQuantity.Quantity -= quantity;
            productQuantity.UpdatedAt = DateTime.Now;
        }

        private Order CreateOrder(Guid orderId, List<OrderProduct> orderProducts, IEnumerable<Product> products)
        {
            return new Order
            {
                Id = orderId,
                TotalAmount = orderProducts.Sum(op => products.Single(p => p.Id == op.ProductId).Price * op.ProductQuantity),
                OrderDate = DateTime.Now,
                OrderProducts = orderProducts
            };
        }

        private async Task SaveOrderAsync(Order order, CancellationToken cancellationToken)
        {
            await _unitOfWork.OrderRepository.AddAsync(order, cancellationToken);
            await _unitOfWork.SaveAsync();
        }


    }
}
