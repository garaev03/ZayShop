using Zay.Entities.DTOs.ProductDtos;

namespace Zay.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductGetDto>> GetAllAsync();
        Task<ProductGetDto> GetByIdAsync(int id);
        Task Create(ProductPostDto postDto);
        Task Update(ProductUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
