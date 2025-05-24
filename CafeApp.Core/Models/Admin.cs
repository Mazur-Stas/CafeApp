namespace CafeApp.Core.Models;

public class Admin : User
{
    public ICollection<Employee> Employees { get; set; }
}
