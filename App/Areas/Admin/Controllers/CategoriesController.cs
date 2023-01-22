using Microsoft.AspNetCore.Mvc;
using Zay.Business.Services.Interfaces;
using Zay.Entities.DTOs.BrandDtos;
using Zay.Entities.DTOs.CategoryDtos;

namespace Zay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<CategoryGetDto> categories = new();
            try
            {
                categories = await _service.GetAllAsync();
            }
            catch { categories = new(); }
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDto categoryPost)
        {
            if (!ModelState.IsValid) { return View(); }
            try
            {
                await _service.Create(categoryPost);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Image", ex.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            CategoryGetDto category = new();
            try
            {
                category = await _service.GetByIdAsync(id);
            }
            catch { return NotFound(); }
            CategoryUpdateDto categoryUpdate = new() { getDto = category };
            return View(categoryUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdate)
        {
            try
            {
                categoryUpdate.getDto = await _service.GetByIdAsync(categoryUpdate.getDto.Id);
            }
            catch { return NotFound(); }
            if (!ModelState.IsValid) return View(categoryUpdate);
            try
            {
                await _service.Update(categoryUpdate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Image", ex.Message);
                return View(categoryUpdate);
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
