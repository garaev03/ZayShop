namespace Zay.Entities.Concrets
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ShowSalePrice { get; set; }
        public int TotalCount { get; set; }
        public bool isDeleted { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public List<ProductSpesification> Spesifications { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductSizeColorDiscount> ProductSizeColorDiscounts { get; set; }
        public Product()
        {
            Brand = new();
            Category = new();
            Spesifications = new();
            ProductImages = new();
            ProductSizeColorDiscounts = new();
        }
    }
}
