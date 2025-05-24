using CafeApp.Core.DTOs.Inputs;
using CafeApp.Core.Interfaces;
using CafeApp.Core.Models;

namespace CafeApp.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    /// <summary>
    /// Places an order and saves it to db
    /// </summary>
    /// <param name="orderDto">Test</param>
    /// <param name="cancellationToken"></param>
    /// <returns>new entity of order</returns>
    /// <exception cref="ArgumentException">validation error</exception>
    public async Task<Order> PlaceOrderAsync(AddOrderDto orderDto, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(orderDto.Address))
        {
            throw new ArgumentException("Address cannot be null or empty", nameof(orderDto.Address));
        }

        var order = new Order
        {
            Address = orderDto.Address,
            CreatedAt = DateTime.UtcNow,
            CustomerId = orderDto.CustomerId,
            Products = await _orderRepository.GetProductsByIdsAsync(orderDto.ProductsIds, cancellationToken)
        };

        return await _orderRepository.PlaceOrderAsync(order, cancellationToken);
    }
}
