using CafeApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Storage;

public class CafeAppContext : DbContext
{
    private readonly string _connectionString;

    public CafeAppContext()
    {
        
    }

    public CafeAppContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CafeAppDB;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CafeAppContext).Assembly);

    public DbSet<Order> Orders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
