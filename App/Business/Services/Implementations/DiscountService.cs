using AutoMapper;
using Zay.Business.Services.Interfaces;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.DiscountDtos;

namespace Zay.Business.Services.Implementations
{
    public class DiscountService:IDiscountService
    {

        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;
        public DiscountService(IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<DiscountGetDto>> GetAllAsync()
        {
            List<Discount> discounts = await _repository.GetAllAsync(s => !s.isDeleted);
            if (discounts.Count is 0)
                throw new Exception("not found");
            return _mapper.Map<List<DiscountGetDto>>(discounts);
        }
        public async Task<DiscountGetDto> GetByIdAsync(int id)
        {
            Discount discount = await _repository.GetByIdAsync(id);
            if (discount is null)
                throw new Exception("not found");
            return _mapper.Map<DiscountGetDto>(discount);
        }
        public async Task Create(DiscountPostDto postDto)
        {
            await _repository.Create(_mapper.Map<Discount>(postDto));
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Discount discount = await _repository.GetByIdAsync(id);
            if (discount == null)
                throw new Exception("not found");
            _repository.Delete(discount);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(DiscountUpdateDto updateDto)
        {
            Discount discount = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (discount == null)
                throw new Exception("not found");
            discount.Percent = updateDto.postDto.Percent;
            //_repository.Update(color);
            await _repository.SaveChangesAsync();
        }
    }
}
