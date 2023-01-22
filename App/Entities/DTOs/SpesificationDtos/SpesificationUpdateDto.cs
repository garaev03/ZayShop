namespace Zay.Entities.DTOs.SpesificationDtos
{
    public class SpesificationUpdateDto
    {
        public SpesificationGetDto getDto { get; set; }
        public SpesificationPostDto postDto { get; set; }
        public SpesificationUpdateDto()
        {
            getDto = new();
            postDto = new();
        }
    }
}
