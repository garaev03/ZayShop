namespace Zay.Entities.Concrets
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Link { get; set; }
        public bool isDeleted { get; set; }
        public List<Product> Products { get; set; }
        public Brand()
        {
            Products = new List<Product>();
        }
    }
}
