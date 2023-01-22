using Microsoft.AspNetCore.Mvc;
using Zay.Business.Services.Implementations;
using Zay.Business.Services.Interfaces;
using Zay.Entities.DTOs.ProductDtos;

namespace Zay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        private readonly IDiscountService _discountService;
        private readonly ISpesificationService _spesService;
        public ProductsController(IProductService service, ICategoryService caegoryService, IDiscountService discountService, IColorService colorService, ISizeService sizeService, IBrandService brandService, ISpesificationService spesService)
        {
            _service = service;
            _categoryService = caegoryService;
            _discountService = discountService;
            _colorService = colorService;
            _sizeService = sizeService;
            _brandService = brandService;
            _spesService = spesService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductGetDto> products = new();
            try
            {
                products = await _service.GetAllAsync();
            }
            catch { products = new(); }
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"]=await _categoryService.GetAllAsync();
            ViewData["Brands"]=await _brandService.GetAllAsync();
            ViewData["Sizes"]=await _sizeService.GetAllAsync();
            ViewData["Colors"]=await _colorService.GetAllAsync();
            ViewData["Discounts"]=await _discountService.GetAllAsync();
            ViewData["Spesifications"]=await _spesService.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductPostDto productPost)
        {
            ViewData["Categories"] = await _categoryService.GetAllAsync();
            ViewData["Brands"] = await _brandService.GetAllAsync();
            ViewData["Sizes"] = await _sizeService.GetAllAsync();
            ViewData["Colors"] = await _colorService.GetAllAsync();
            ViewData["Discounts"] = await _discountService.GetAllAsync();
            ViewData["Spesifications"]=await _spesService.GetAllAsync();
            if (!ModelState.IsValid) { return View(); }
            try
            {
                await _service.Create(productPost);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            ProductGetDto product = new();
            try
            {
                product = await _service.GetByIdAsync(id);
            }
            catch { return NotFound(); }
            ProductUpdateDto productUpdate = new() { getDto = product };
            return View(productUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdate)
        {
            try
            {
                productUpdate.getDto = await _service.GetByIdAsync(productUpdate.getDto.Id);
            }
            catch { return NotFound(); }
            if (!ModelState.IsValid) return View(productUpdate);
            try
            {
                await _service.Update(productUpdate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(productUpdate);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
