using Zay.Entities.DTOs.DiscountDtos;

namespace Zay.Business.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<List<DiscountGetDto>> GetAllAsync();
        Task<DiscountGetDto> GetByIdAsync(int id);
        Task Create(DiscountPostDto postDto);
        Task Update(DiscountUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
