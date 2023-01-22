namespace Zay.Entities.DTOs.DiscountDtos
{
    public class DiscountUpdateDto
    {
        public DiscountGetDto getDto { get; set; }
        public DiscountPostDto postDto { get; set; }
        public DiscountUpdateDto()
        {
            getDto= new DiscountGetDto();
            postDto= new DiscountPostDto();
        }
    }
}
