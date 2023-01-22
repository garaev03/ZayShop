using Microsoft.AspNetCore.Mvc;
using Zay.Business.Services.Interfaces;
using Zay.Entities.DTOs.SizeDtos;

namespace Zay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizesController : Controller
    {
        private readonly ISizeService _service;
        public SizesController(ISizeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<SizeGetDto> sizes = new();
            try
            {
                sizes = await _service.GetAllAsync();
            }
            catch { sizes = new(); }
            return View(sizes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SizePostDto sizePost)
        {
            if (!ModelState.IsValid) { return View(); }
            await _service.Create(sizePost);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            SizeGetDto size = new();
            try
            {
                size = await _service.GetByIdAsync(id);
            }
            catch { return NotFound(); }
            SizeUpdateDto sizeUpdate = new() { getDto = size };
            return View(sizeUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SizeUpdateDto sizeUpdate)
        {
            if (!ModelState.IsValid) return View();
            await _service.Update(sizeUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
