namespace Zay.Entities.DTOs.CategoryDtos
{
    public class CategoryUpdateDto
    {
        public CategoryGetDto getDto { get; set; }
        public CategoryPostDto postDto { get; set; }
        public CategoryUpdateDto()
        {
            getDto = new();
            postDto = new CategoryPostDto();
        }

    }
}
