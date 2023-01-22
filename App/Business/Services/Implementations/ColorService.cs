using AutoMapper;
using Zay.Business.Services.Interfaces;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.ColorDtos;

namespace Zay.Business.Services.Implementations;

public class ColorService : IColorService
{
    private readonly IColorRepository _repository;
    private readonly IMapper _mapper;
    public ColorService(IColorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ColorGetDto>> GetAllAsync()
    {
        List<Color> colors = await _repository.GetAllAsync(s => !s.isDeleted);
        if (colors.Count is 0)
            throw new Exception("not found");
        return _mapper.Map<List<ColorGetDto>>(colors);
    }
    public async Task<ColorGetDto> GetByIdAsync(int id)
    {
        Color color = await _repository.GetByIdAsync(id);
        if (color is null)
            throw new Exception("not found");
        return _mapper.Map<ColorGetDto>(color);
    }
    public async Task Create(ColorPostDto postDto)
    {
        await _repository.Create(_mapper.Map<Color>(postDto));
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Color color = await _repository.GetByIdAsync(id);
        if (color == null)
            throw new Exception("not found");
        _repository.Delete(color);
        await _repository.SaveChangesAsync();
    }
    public async Task Update(ColorUpdateDto updateDto)
    {
        Color color = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (color == null)
            throw new Exception("not found");
        color.Value = updateDto.postDto.Value;
        //_repository.Update(color);
        await _repository.SaveChangesAsync();
    }
}
