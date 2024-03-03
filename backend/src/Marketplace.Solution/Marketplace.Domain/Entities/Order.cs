using System;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class Order
    {
        public string OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        // Status could be an Enum or String
        public string Status { get; set; }

        // Foreign Key
        public string UserId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}