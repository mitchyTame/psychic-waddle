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
    
    private DbSet<Customer> Customers { get; set; }
    private DbSet<CustomerAddress> CustomerAddresses { get; set; }
    private DbSet<Product> Products { get; set; }
    private DbSet<ProductInventory> ProductInventories { get; set; }
    private DbSet<ProductInventorySnapshot> ProductInventorySnapShot { get; set; }
    private DbSet<SalesOrder> SalesOrder { get; set; }
    private DbSet<SalesOrderItem> SalesOrderItems { get; set; }
}