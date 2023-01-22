namespace Zay.Entities.Concrets
{
    public class ProductSpesification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isDeleted { get; set; }
        public List<Product> Products { get; set; }
        public ProductSpesification()
        {
            Products = new();
        }
    }
}
