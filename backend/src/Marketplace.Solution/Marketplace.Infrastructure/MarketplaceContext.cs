using System;
using System.Data.Entity;
using Marketplace.Domain.Entities;

public class MarketplaceContext : DbContext
{
    public MarketplaceContext()
        : base("name=MarketplaceContext") // Specify the name of the connection string
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}
