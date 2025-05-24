using CafeApp.Core.DTOs.Inputs;
using CafeApp.Core.Models;

namespace CafeApp.Core.Interfaces;

public interface IOrderService
{
    Task<Order> PlaceOrderAsync(AddOrderDto orderDto, CancellationToken cancellationToken);
}
