using System;
using System.Data.Entity.Migrations;
using Marketplace.Domain.Entities;

namespace Marketplace.Infrastructure
{
    internal sealed class Configuration : DbMigrationsConfiguration<MarketplaceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MarketplaceContext context)
        {
            // Roles
            var adminRoleId = Guid.NewGuid().ToString();
            var defaultUserRoleId = Guid.NewGuid().ToString();
            context.Roles.AddOrUpdate(r => r.Name,
                new Role { RoleId = adminRoleId, Name = "Admin" },
                new Role { RoleId = defaultUserRoleId, Name = "User" }
            );

            // Admin user
            context.Users.AddOrUpdate(u => u.Username,
                new User
                {
                    UserId = Guid.NewGuid().ToString(),
                    Username = "admin",
                    Email = "admin@example.com",
                    PasswordSalt = new byte[128 / 8], // Ensure this is generated appropriately
                    PasswordHash = "hash", // Ensure this is hashed appropriately
                    RoleId = adminRoleId
                }
            );

            // Orders
            context.Orders.AddOrUpdate(o => o.OrderId,
                new Order
                {
                    OrderId = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.Now.ToUniversalTime(),
                    TotalPrice = 100.00m,
                    Status = "Pending",
                    UserId = defaultUserRoleId
                },
                new Order
                {
                    OrderId = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.Now.ToUniversalTime(),
                    TotalPrice = 200.00m,
                    Status = "Delivered",
                    UserId = defaultUserRoleId
                }
            );

            // Make sure to save changes after adding all the data
            context.SaveChanges();
        }
    }

}