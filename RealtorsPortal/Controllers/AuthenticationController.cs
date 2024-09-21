using Microsoft.AspNetCore.Mvc;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class AuthenticationController : Controller
    {
       ApplicationDbContext _con;
        public AuthenticationController(ApplicationDbContext con)
        {
            this._con = con;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Agent agent)
        {
            _con.Agents.Add(agent);
            _con.SaveChanges();
            TempData["register"] = "SUCCESSFULLY REGISTERED";
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Agent agent)
        {
            var data = _con.Agents.Where(e => e.Email == agent.Email && e.Password == agent.Password).FirstOrDefault();

            if (data != null)
            {
                HttpContext.Session.SetString("mysession", data.Email);
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                TempData["login"] = "THIS EMAIL DOESN'T EXIST";
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                HttpContext.Session.Remove("mysession");
                TempData["logout"] = "SUCCESSFULLY LOGOUT";
                return RedirectToAction("login");
            }
            return View();
        }
    }
}
