using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class ContactController : Controller
    {
        ApplicationDbContext con;
        public ContactController(ApplicationDbContext _con)
        {
            this.con = _con;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.ContactUs.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }
        public IActionResult Delete(int id) {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.ContactUs.Where(a => a.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }   
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Deletecon(int id)
        {
            var data = con.ContactUs.Find(id);
            con.ContactUs.Remove(data);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
