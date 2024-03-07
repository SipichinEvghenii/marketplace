namespace Marketplace.Domain.Entities
{
    public class Product
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string ImageUrl { get; set; }

        // Foreign Key
        public string CategoryId { get; set; }

        // Navigation Property
        public Category Category { get; set; }
    }
}