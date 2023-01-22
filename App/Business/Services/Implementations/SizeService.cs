using AutoMapper;
using Zay.Business.Services.Interfaces;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.DTOs.SizeDtos;
using Size = Zay.Entities.Concrets.Size;

namespace Zay.Business.Services.Implementations;

public class SizeService : ISizeService
{
    private readonly ISizeRepository _repository;
    private readonly IMapper _mapper;
    public SizeService(ISizeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<SizeGetDto>> GetAllAsync()
    {
        List<Size> sizes = await _repository.GetAllAsync(s => !s.isDeleted);
        if (sizes.Count is 0)
            throw new Exception("not found");
        return _mapper.Map<List<SizeGetDto>>(sizes);
    }
    public async Task<SizeGetDto> GetByIdAsync(int id)
    {
        Size size = await _repository.GetByIdAsync(id);
        if (size is null)
            throw new Exception("not found");
        return _mapper.Map<SizeGetDto>(size);
    }
    public async Task Create(SizePostDto postDto)
    {
        await _repository.Create(_mapper.Map<Size>(postDto));
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Size size = await _repository.GetByIdAsync(id);
        if (size == null)
            throw new Exception("not found");
        _repository.Delete(size);
        await _repository.SaveChangesAsync();
    }
    public async Task Update(SizeUpdateDto updateDto)
    {
        Size size = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (size == null)
            throw new Exception("not found");
        size.Value=updateDto.postDto.Value;
        //_repository.Update(size);
        await _repository.SaveChangesAsync();
    }
}
