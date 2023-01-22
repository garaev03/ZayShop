namespace Zay.Entities.Concrets
{
    public class ProductSizeColorDiscount
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int DiscountId { get; set; }
        public int Count { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SalePrice { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public Discount Discount { get; set; }
    }
}
