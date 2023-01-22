using Zay.Entities.Concrets;

namespace Zay.Entities.DTOs.SpesificationDtos
{
    public class SpesificationGetDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<Product> Products { get; set; }
        public SpesificationGetDto()
        {
            Products = new();
        }
    }
}
