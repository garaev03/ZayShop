using Microsoft.AspNetCore.Mvc;

namespace Zay.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
