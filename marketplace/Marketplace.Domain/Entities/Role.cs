using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class Role
    {
        public string RoleId { get; set; }

        public string Name { get; set; }

        // Navigation Property for Users
        public ICollection<User> Users { get; set; }
    }
}