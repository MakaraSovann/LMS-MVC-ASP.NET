using Microsoft.AspNetCore.Mvc;

namespace LMSMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
