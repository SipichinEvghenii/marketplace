namespace Marketplace.Domain.Entities
{
    public class OrderDetail
    {
        public string OrderDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        // Foreign Keys
        public string OrderId { get; set; }
        public string ProductId { get; set; }

        // Navigation Properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}