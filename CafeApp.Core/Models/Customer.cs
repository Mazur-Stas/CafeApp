namespace CafeApp.Core.Models;

public class Customer : User
{
    public string Address { get; set; }
    public string Card { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
