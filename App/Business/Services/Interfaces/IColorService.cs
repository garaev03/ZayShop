using Zay.Entities.DTOs.ColorDtos;

namespace Zay.Business.Services.Interfaces
{
    public interface IColorService
    {
        Task<List<ColorGetDto>> GetAllAsync();
        Task<ColorGetDto> GetByIdAsync(int id);
        Task Create(ColorPostDto postDto);
        Task Update(ColorUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
