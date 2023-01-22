using Microsoft.AspNetCore.Mvc;

namespace Zay.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
