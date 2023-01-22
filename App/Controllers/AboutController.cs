using Microsoft.AspNetCore.Mvc;

namespace Zay.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
