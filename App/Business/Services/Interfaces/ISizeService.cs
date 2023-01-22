using Zay.Entities.DTOs.SizeDtos;

namespace Zay.Business.Services.Interfaces
{
    public interface ISizeService
    {
        Task<List<SizeGetDto>> GetAllAsync();
        Task<SizeGetDto> GetByIdAsync(int id);
        Task Create(SizePostDto postDto);
        Task Update(SizeUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
