namespace Zay.Entities.DTOs.BrandDtos
{
    public class BrandUpdateDto
    {
        public BrandGetDto getDto { get; set; }
        public BrandPostDto postDto { get; set; }
        public BrandUpdateDto()
        {
            getDto= new BrandGetDto();
            postDto= new BrandPostDto();
        }
    }
}
