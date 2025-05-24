namespace CafeApp.Core.Models;

public class Order : EntityChanges
{
    public int Id { get; set; }
    public string Address { get; set; }

    public ICollection<Product> Products { get; set; }
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    public decimal TotalPrice => Products.Sum(p => p.Price);
}
