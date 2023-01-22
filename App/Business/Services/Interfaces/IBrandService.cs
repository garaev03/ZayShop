using Zay.Entities.DTOs.BrandDtos;

namespace Zay.Business.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandGetDto>> GetAllAsync();
        Task<BrandGetDto> GetByIdAsync(int id);
        Task Create(BrandPostDto postDto);
        Task Update(BrandUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
