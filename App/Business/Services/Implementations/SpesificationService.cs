using AutoMapper;
using Zay.Business.Services.Interfaces;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.SpesificationDtos;

namespace Zay.Business.Services.Implementations
{
    public class SpesificationService:ISpesificationService
    {
        private readonly ISpesificationRepository _repository;
        private readonly IMapper _mapper;
        public SpesificationService(ISpesificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SpesificationGetDto>> GetAllAsync()
        {
            List<ProductSpesification> Spesifications = await _repository.GetAllAsync(s => !s.isDeleted);
            if (Spesifications.Count is 0)
                throw new Exception("not found");
            return _mapper.Map<List<SpesificationGetDto>>(Spesifications);
        }
        public async Task<SpesificationGetDto> GetByIdAsync(int id)
        {
            ProductSpesification Spesification = await _repository.GetByIdAsync(id);
            if (Spesification is null)
                throw new Exception("not found");
            return _mapper.Map<SpesificationGetDto>(Spesification);
        }
        public async Task Create(SpesificationPostDto postDto)
        {
            await _repository.Create(_mapper.Map<ProductSpesification>(postDto));
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            ProductSpesification Spesification = await _repository.GetByIdAsync(id);
            if (Spesification == null)
                throw new Exception("not found");
            _repository.Delete(Spesification);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(SpesificationUpdateDto updateDto)
        {
            ProductSpesification Spesification = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (Spesification == null)
                throw new Exception("not found");
            Spesification.Title = updateDto.postDto.Title;
            //_repository.Update(Spesification);
            await _repository.SaveChangesAsync();
        }
    }
}
