using CafeApp.Core.Models;

namespace CafeApp.Core.Interfaces;

public interface IOrderRepository
{
    Task<Order> PlaceOrderAsync(Order order, CancellationToken cancellationToken);

    Task<ICollection<Product>> GetProductsByIdsAsync(IEnumerable<int> productIds, CancellationToken cancellationToken);
}
