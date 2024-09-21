using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RealtorsPortal.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }
    }
}
