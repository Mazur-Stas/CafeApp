using CafeApp.Core.Models;

namespace CafeApp.Core.DTOs.Inputs;

public class AddOrderDto
{
    public string Address { get; set; }

    public ICollection<int> ProductsIds { get; set; }
    public int CustomerId { get; set; }
}
