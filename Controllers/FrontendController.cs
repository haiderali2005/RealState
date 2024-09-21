using Microsoft.AspNetCore.Mvc;

namespace RealtorsPortal.Controllers
{
    public class FrontendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Properties()
        {
            return View();
        }
    }
}
