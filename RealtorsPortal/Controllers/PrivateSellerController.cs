using Microsoft.AspNetCore.Mvc;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class PrivateSellerController : Controller
    {
        ApplicationDbContext _con;

        public PrivateSellerController(ApplicationDbContext con)
        {
            _con = con;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(PrivateSeller privateseller)
        {
            _con.PrivateSellers.Add(privateseller);
            _con.SaveChanges();
            TempData["register"] = "SUCCESSFULLY REGISTERED";
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(PrivateSeller privateseller)
        {
            var data = _con.PrivateSellers.Where(user => user.Email == privateseller.Email && user.Password == privateseller.Password).FirstOrDefault();

            if (data != null)
            {
                HttpContext.Session.SetInt32("mypvtuser", data.PrivateSellerId);
                return RedirectToAction("Create", "PrivateSellerProperty");
            }
            else
            {
                TempData["login"] = "THIS EMAIL DOESN'T EXIST";
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetInt32("mypvtuser") != null)
            {
                HttpContext.Session.Remove("mypvtuser");
                TempData["logout"] = "SUCCESSFULLY LOGOUT";
                return RedirectToAction("login");
            }
            return View();
        }
    }
}
