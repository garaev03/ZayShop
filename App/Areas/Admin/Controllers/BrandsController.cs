using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Zay.Business.Services.Interfaces;
using Zay.Entities.DTOs.BrandDtos;

namespace Zay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IBrandService _service;
        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<BrandGetDto> brands = new();
            try
            {
                brands = await _service.GetAllAsync();
            }
            catch { brands = new(); }
            return View(brands);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandPostDto brandPost)
        {
            if (!ModelState.IsValid) { return View(); }
            try
            {
                await _service.Create(brandPost);
            }catch(Exception ex)
            {
                ModelState.AddModelError("Logo", ex.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            BrandGetDto brand = new();
            try
            {
                brand = await _service.GetByIdAsync(id);
            }
            catch { return NotFound(); }
            BrandUpdateDto brandUpdate = new() { getDto = brand };
            return View(brandUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BrandUpdateDto brandUpdate)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                await _service.Update(brandUpdate); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Logo", ex.Message);
                return View();
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
