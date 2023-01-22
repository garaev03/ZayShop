using AutoMapper;
using Zay.Business.Services.Interfaces;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.BrandDtos;
using Zay.Entities.DTOs.CategoryDtos;
using Zay.Entities.DTOs.ColorDtos;
using Zay.Entities.DTOs.DiscountDtos;
using Zay.Entities.DTOs.ProductDtos;
using Zay.Entities.DTOs.SizeDtos;
using Zay.Entities.DTOs.SpesificationDtos;

namespace Zay.Business.Services.Implementations
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        private readonly IDiscountService _discountService;
        private readonly ISpesificationService _spesificationService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        public ProductService(IProductRepository repository, IMapper mapper, IImageService imageService, IWebHostEnvironment env, IBrandService brandService, ICategoryService categoryService, ISizeService sizeService, IDiscountService discountService, IColorService colorService, ISpesificationService spesificationService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
            _brandService = brandService;
            _categoryService = categoryService;
            _sizeService = sizeService;
            _discountService = discountService;
            _colorService = colorService;
            _spesificationService = spesificationService;
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
            BrandGetDto brand = await _brandService.GetByIdAsync(postDto.BrandId);
            if (brand is null) throw new Exception("Invalid Brand.");

            CategoryGetDto category = await _categoryService.GetByIdAsync(postDto.CategoryId);
            if (category is null) throw new Exception("Invalid Category.");

            List<List<int>> Colors = GetColors(postDto.ColorIds);
            List<ProductSizeColorDiscount> pscd = await GetSizeColorDiscountAsync(postDto.SizeIds, Colors, postDto.DiscountIds, postDto.Counts, postDto.BuyPrices, postDto.SellPrices);

            if (postDto.Images.Count == 0) throw new Exception("Enter at least 1 image.");
            List<ProductImage> Images = await CheckAndCreateImage(postDto.Images);

            Product NewProduct = new()
            {
                Name = postDto.Name,
                Description = postDto.Description,
                isDeleted = false,
                ProductImages = Images,
                ShowSalePrice = postDto.SellPrices.FirstOrDefault(),
                TotalCount = GetTotalCount(postDto.Counts),
                Brand = _mapper.Map<Brand>(brand),
                Category = _mapper.Map<Category>(category),
                ProductSizeColorDiscounts = pscd,
                Spesifications = await GetSpesifications(postDto.SpesificationIds),
            };
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
                Images = await CheckAndCreateImage(updateDto.postDto.Images);
                Product.ProductImages = Product.ProductImages.Concat(Images).ToList();
            }

            Product.Name = updateDto.postDto.Name;
            Product.Description = updateDto.postDto.Description;
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
        private int GetTotalCount(List<int> Counts)
        {
            int TotalCount = 0;

            foreach (int count in Counts)
            {
                TotalCount += count;
            }
            return TotalCount;
        }
        private List<List<int>> GetColors(List<int> ColorIds)
        {
            List<List<int>> SplittedColorIds = new();
            List<int> PerIds = new();
            foreach (int id in ColorIds)
            {
                if (id == -1)
                {
                    if (PerIds.Count == 0)
                        throw new Exception("Enter at least 1 color.");
                    SplittedColorIds.Add(PerIds);
                    PerIds = new();
                }
                PerIds.Add(id);
            }
            return SplittedColorIds;
        }
        private async Task<List<ProductSpesification>> GetSpesifications(List<int> SpesIds)
        {
            List<ProductSpesification> ps = new();
            foreach (int id in SpesIds)
            {
                SpesificationGetDto spes = await _spesificationService.GetByIdAsync(id);
                if (spes is null) throw new Exception("Invalid Spesification.");
                ps.Add(_mapper.Map<ProductSpesification>(spes));
            }
            return ps;
        }
        private async Task<List<ProductSizeColorDiscount>> GetSizeColorDiscountAsync(List<int> SizeIds, List<List<int>> ColorIds, List<int> DiscountIds, List<int> Counts, List<int> BuyPrices, List<int> SellPrices)
        {
            List<ProductSizeColorDiscount> pscds = new();
            for (int i = 0; i < SizeIds.Count; i++)
            {
                SizeGetDto size = await _sizeService.GetByIdAsync(SizeIds[i]);
                if (size is null) throw new Exception("Invalid Size.");

                DiscountGetDto discount = await _discountService.GetByIdAsync(DiscountIds[i]);
                if (discount is null) throw new Exception("Invalid Discount.");

                for (int j = 0; j < ColorIds[i].Count; j++)
                {
                    ColorGetDto color = await _colorService.GetByIdAsync(ColorIds[i][j]);
                    if (color is null) throw new Exception("Invalid Color.");

                    ProductSizeColorDiscount pscd = new();
                    pscd.Size = _mapper.Map<Size>(size);
                    pscd.Color = _mapper.Map<Color>(color);
                    pscd.Discount = _mapper.Map<Discount>(discount);
                    pscd.Count = Counts[i];
                    pscd.BuyPrice = BuyPrices[i];
                    pscd.SalePrice = SellPrices[i];
                    pscds.Add(pscd);
                }
            }
            return pscds;
        }
    }
}
