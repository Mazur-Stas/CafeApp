using CafeApp.Core.Interfaces;
using CafeApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Storage.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly CafeAppContext _context;

    public OrderRepository(CafeAppContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Product>> GetProductsByIdsAsync(IEnumerable<int> productIds, CancellationToken cancellationToken)
    {
        return await _context.Products.Where(p => productIds.Contains(p.Id))
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Order> PlaceOrderAsync(Order order, CancellationToken cancellationToken)
    {
        _context.Orders.Add(order);

        await _context.SaveChangesAsync(cancellationToken);

        return order;
    }
}
