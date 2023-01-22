using Zay.Entities.Concrets;

namespace Zay.Entities.DTOs.CategoryDtos
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public List<Product> Products { get; set; }
        public CategoryGetDto()
        {
            Products = new();
        }
    }
}
