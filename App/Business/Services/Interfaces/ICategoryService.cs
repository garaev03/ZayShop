using Zay.Entities.DTOs.CategoryDtos;

namespace Zay.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryGetDto>> GetAllAsync();
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task Create(CategoryPostDto postDto);
        Task Update(CategoryUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
