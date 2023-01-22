namespace Zay.Entities.DTOs.ProductDtos
{
    public class ProductUpdateDto
    {
        public ProductGetDto getDto { set; get; }
        public ProductPostDto postDto { set; get; }
        public ProductUpdateDto()
        {
            getDto=new ProductGetDto();
            postDto=new ProductPostDto();
        }
    }
}
