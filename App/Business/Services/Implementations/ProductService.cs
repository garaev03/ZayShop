using AutoMapper;
using Zay.Business.Services.Interfaces;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.ProductDtos;

namespace Zay.Business.Services.Implementations
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        public ProductService(IProductRepository repository, IMapper mapper, IImageService imageService, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
        }

        public async Task<List<ProductGetDto>> GetAllAsync()
        {
            List<Product> Products = await _repository.GetAllAsync(s => !s.isDeleted);
            if (Products.Count is 0)
                throw new Exception("not found");
            return _mapper.Map<List<ProductGetDto>>(Products);
        }
        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            Product Product = await _repository.GetByIdAsync(id);
            if (Product is null)
                throw new Exception("not found");
            return _mapper.Map<ProductGetDto>(Product);
        }
        public async Task Create(ProductPostDto postDto)
        {
            List<ProductImage> Images;
            try
            {
                if (postDto.Images.Count == 0)
                    throw new Exception("Enter at least 1 image.");
                Images = await CheckAndCreateImage(postDto.Images);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Product NewProduct = _mapper.Map<Product>(postDto);
            NewProduct.ProductImages = Images;
            await _repository.Create(NewProduct);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Product Product = await _repository.GetByIdAsync(id);
            if (Product == null)
                throw new Exception("not found");
            _repository.Delete(Product);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(ProductUpdateDto updateDto)
        {
            Product Product = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (Product == null)
                throw new Exception("not found");
            if (updateDto.postDto.Images.Count != 0)
            {
                List<ProductImage> Images;
                try
                {
                    Images = await CheckAndCreateImage(updateDto.postDto.Images);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                Product.ProductImages.Add();
            }
            Product.Name = updateDto.postDto.Name;
            //_repository.Update(color);
            await _repository.SaveChangesAsync();
        }

        private async Task<List<ProductImage>> CheckAndCreateImage(List<IFormFile> images)
        {
            List<ProductImage> Images = new();
            try
            {
                foreach (var formFile in images)
                {
                    _imageService.CheckSize(formFile);
                    _imageService.CheckImageType(formFile);
                    string ImageName = await _imageService.CreateImageAsync(_env.WebRootPath, "assets/img/product-images/", formFile);
                    ProductImage image = new()
                    {
                        Path = ImageName,
                        isMain = false,
                        isDeleted = false,
                    };
                    if (images.IndexOf(formFile) == 0)
                        image.isMain = true;
                    Images.Add(image);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Images;
        }
    }
}
