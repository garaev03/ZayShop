namespace Zay.Entities.Concrets
{
    public class Discount
    {
        public int Id { get; set; }
        public int Percent { get; set; }
        public bool isDeleted { get; set; }
        public List<ProductSizeColorDiscount> ProductSizeColorDiscounts { get; set; }
        public Discount()
        {
            ProductSizeColorDiscounts = new();
        }
    }
}
