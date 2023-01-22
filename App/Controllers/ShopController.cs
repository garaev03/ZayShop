using Microsoft.AspNetCore.Mvc;

namespace Zay.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
