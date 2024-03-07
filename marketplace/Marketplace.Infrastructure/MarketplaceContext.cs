using System;
using System.Data.Entity;
using Marketplace.Domain.Entities;

public class MarketplaceContext : DbContext
{
    public MarketplaceContext()
        : base("name=postgresql") // Specify the name of the connection string
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration for relationships
        modelBuilder.Entity<Category>()
            .HasMany(c => c.SubCategories)
            .WithOptional(c => c.ParentCategory)
            .HasForeignKey(c => c.ParentCategoryId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithRequired(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        modelBuilder.Entity<User>()
            .HasRequired(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<OrderDetail>()
            .HasRequired(od => od.Product)
            .WithMany()
            .HasForeignKey(od => od.ProductId);
    }
}
