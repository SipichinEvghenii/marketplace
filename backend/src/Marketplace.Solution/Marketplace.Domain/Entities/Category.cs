using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class Category
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Parent Category Relationship
        public string ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        // Navigation Property for Subcategories and Products
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}