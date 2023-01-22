namespace Zay.Entities.Concrets
{
    public class ProductImage
    {
        public int Id { get; set; } 
        public string Path { get; set; }
        public bool isMain { get; set; }
        public bool isDeleted { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ProductImage()
        {
            Product = new();
        }
    }
}
