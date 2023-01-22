namespace Zay.Entities.DTOs.SizeDtos
{
    public class SizeUpdateDto
    {
        public SizeGetDto getDto { get; set; }
        public SizePostDto postDto { get; set; }
        public SizeUpdateDto()
        {
            getDto= new SizeGetDto();
            postDto= new SizePostDto(); 
        }
    }
}
