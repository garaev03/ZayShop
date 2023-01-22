using AutoMapper;
using Zay.Business.Services.Interfaces;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.CategoryDtos;

namespace Zay.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        public CategoryService(ICategoryRepository repository, IMapper mapper, IImageService imageService, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
        }

        public async Task<List<CategoryGetDto>> GetAllAsync()
        {
            List<Category> categorys = await _repository.GetAllAsync(s => !s.isDeleted);
            if (categorys.Count is 0)
                throw new Exception("not found");
            return _mapper.Map<List<CategoryGetDto>>(categorys);
        }
        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category is null)
                throw new Exception("not found");
            return _mapper.Map<CategoryGetDto>(category);
        }
        public async Task Create(CategoryPostDto postDto)
        {
            string ImageName;
            try
            {
                if (postDto.Image is null)
                    throw new Exception("Enter image.");
                ImageName = await CheckAndCreateImage(postDto.Image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Category newcategory = _mapper.Map<Category>(postDto);
            newcategory.Image = ImageName;
            await _repository.Create(newcategory);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category == null)
                throw new Exception("not found");
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(CategoryUpdateDto updateDto)
        {
            Category category = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (category == null)
                throw new Exception("not found");
            if (updateDto.postDto.Image is not null)
            {
                string ImageName;
                try
                {
                    ImageName = await CheckAndCreateImage(updateDto.postDto.Image);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                category.Image = ImageName;
            }
            category.Name = updateDto.postDto.Name;
            //_repository.Update(color);
            await _repository.SaveChangesAsync();
        }

        private async Task<string> CheckAndCreateImage(IFormFile image)
        {
            string ImageName;
            try
            {
                _imageService.CheckSize(image);
                _imageService.CheckImageType(image);
                ImageName = await _imageService.CreateImageAsync(_env.WebRootPath, "assets/img/category-images/", image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ImageName;
        }
    }
}
