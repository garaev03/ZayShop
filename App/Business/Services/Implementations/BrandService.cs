using AutoMapper;
using Zay.Business.Services.Interfaces;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.BrandDtos;

namespace Zay.Business.Services.Implementations
{
    public class BrandService : IBrandService
    {

        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        public BrandService(IBrandRepository repository, IMapper mapper, IImageService imageService, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
        }

        public async Task<List<BrandGetDto>> GetAllAsync()
        {
            List<Brand> brands = await _repository.GetAllAsync(s => !s.isDeleted);
            if (brands.Count is 0)
                throw new Exception("not found");
            return _mapper.Map<List<BrandGetDto>>(brands);
        }
        public async Task<BrandGetDto> GetByIdAsync(int id)
        {
            Brand brand = await _repository.GetByIdAsync(id);
            if (brand is null)
                throw new Exception("not found");
            return _mapper.Map<BrandGetDto>(brand);
        }
        public async Task Create(BrandPostDto postDto)
        {
            string ImageName;
            try
            {
                if (postDto.Logo is null)
                    throw new Exception("Enter image.");
                ImageName = await CheckAndCreateImage(postDto.Logo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Brand newBrand = _mapper.Map<Brand>(postDto);
            newBrand.Logo = ImageName;
            await _repository.Create(newBrand);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Brand brand = await _repository.GetByIdAsync(id);
            if (brand == null)
                throw new Exception("not found");
            _repository.Delete(brand);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(BrandUpdateDto updateDto)
        {
            Brand brand = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (brand == null)
                throw new Exception("not found");
            if (updateDto.postDto.Logo is not null)
            {
                string ImageName;
                try
                {
                    ImageName = await CheckAndCreateImage(updateDto.postDto.Logo);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                brand.Logo = ImageName;
            }
            brand.Link = updateDto.postDto.Link;
            brand.Name = updateDto.postDto.Name;
            //_repository.Update(color);
            await _repository.SaveChangesAsync();
        }

        private async Task<string> CheckAndCreateImage(IFormFile logo)
        {
            string ImageName;
            try
            {
                _imageService.CheckSize(logo);
                _imageService.CheckImageType(logo);
                ImageName = await _imageService.CreateImageAsync(_env.WebRootPath, "assets/img/brand-logos/", logo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ImageName;
        }
    }
}
