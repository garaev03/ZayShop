using Microsoft.AspNetCore.Mvc;
using Zay.Business.Services.Interfaces;
using Zay.Entities.DTOs.DiscountDtos;

namespace Zay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountsController : Controller
    {
        private readonly IDiscountService _service;
        public DiscountsController(IDiscountService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<DiscountGetDto> discounts = new();
            try
            {
                discounts = await _service.GetAllAsync();
            }
            catch { discounts = new(); }
            return View(discounts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DiscountPostDto discountPost)
        {
            if (!ModelState.IsValid) { return View(); }
            await _service.Create(discountPost);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            DiscountGetDto discount = new();
            try
            {
                discount = await _service.GetByIdAsync(id);
            }
            catch { return NotFound(); }
            DiscountUpdateDto discountUpdate = new() { getDto = discount };
            return View(discountUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DiscountUpdateDto discountUpdate)
        {
            if (!ModelState.IsValid) return View();
            await _service.Update(discountUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
