using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using solarcoffee_data.Models;

namespace solarcoffee_data;

public class SolarDbContext : IdentityDbContext
{
    public SolarDbContext() {}

    public SolarDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductInventory> ProductInventories { get; set; }
    public DbSet<ProductInventorySnapshot> ProductInventorySnapShot { get; set; }
    public DbSet<SalesOrder> SalesOrder { get; set; }
    public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
}