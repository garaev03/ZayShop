using Zay.Entities.Concrets;

namespace Zay.Entities.DTOs.BrandDtos
{
    public class BrandGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? Link { get; set; }
        public List<Product> Products { get; set; }
        public BrandGetDto()
        {
            Products= new List<Product>();
        }
    }
}
