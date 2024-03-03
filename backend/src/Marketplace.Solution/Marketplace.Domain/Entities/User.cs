using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class User
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        // Foreign Key for Role
        public string RoleId { get; set; }

        // Navigation Property for Role
        public Role Role { get; set; }

        // Navigation Property for Orders
        public ICollection<Order> Orders { get; set; }
    }
}