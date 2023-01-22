using Zay.Entities.DTOs.SpesificationDtos;

namespace Zay.Business.Services.Interfaces
{
    public interface ISpesificationService
    {
        Task<List<SpesificationGetDto>> GetAllAsync();
        Task<SpesificationGetDto> GetByIdAsync(int id);
        Task Create(SpesificationPostDto postDto);
        Task Update(SpesificationUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
