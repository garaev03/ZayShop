using Microsoft.AspNetCore.Mvc;
using Zay.Business.Services.Interfaces;
using Zay.Entities.DTOs.ColorDtos;
using Zay.Entities.DTOs.SizeDtos;

namespace Zay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly IColorService _service;
        public ColorsController(IColorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<ColorGetDto> colors = new();
            try
            {
                colors = await _service.GetAllAsync();
            }
            catch { colors = new(); }
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorPostDto colorPost)
        {
            if (!ModelState.IsValid) { return View(); }
            await _service.Create(colorPost);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            ColorGetDto color = new();
            try
            {
                color = await _service.GetByIdAsync(id);
            }
            catch { return NotFound(); }
            ColorUpdateDto colorUpdate = new() { getDto = color };
            return View(colorUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ColorUpdateDto colorUpdate)
        {
            if (!ModelState.IsValid) return View();
            await _service.Update(colorUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
