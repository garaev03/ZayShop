namespace Zay.Entities.Concrets;

public class Size
{
    public int Id { get; set; }
    public string Value { get; set; }
    public bool isDeleted { get; set; }
    public List<ProductSizeColorDiscount> ProductSizeColorDiscounts { get; set; }
    public Size()
    {
        ProductSizeColorDiscounts = new();
    }
}
