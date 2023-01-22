namespace Zay.Entities.DTOs.BrandDtos
{
    public class BrandPostDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
