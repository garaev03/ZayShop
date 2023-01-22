using Microsoft.AspNetCore.Mvc;
using Zay.Business.Services.Implementations;
using Zay.Business.Services.Interfaces;
using Zay.Entities.DTOs.SpesificationDtos;

namespace Zay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpesificationsController : Controller
    {
        private readonly ISpesificationService _service;
        public SpesificationsController(ISpesificationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<SpesificationGetDto> Spesifications = new();
            try
            {
                Spesifications = await _service.GetAllAsync();
            }
            catch { Spesifications = new(); }
            return View(Spesifications);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpesificationPostDto SpesificationPost)
        {
            if (!ModelState.IsValid) { return View(); }
            await _service.Create(SpesificationPost);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            SpesificationGetDto Spesification = new();
            try
            {
                Spesification = await _service.GetByIdAsync(id);
            }
            catch { return NotFound(); }
            SpesificationUpdateDto SpesificationUpdate = new() { getDto = Spesification };
            return View(SpesificationUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SpesificationUpdateDto SpesificationUpdate)
        {
            if (!ModelState.IsValid) return View();
            await _service.Update(SpesificationUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
