using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class PrivateSellersDashboardController : Controller
    {
        ApplicationDbContext con;
        public PrivateSellersDashboardController(ApplicationDbContext conn)
        {
            this.con = conn;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.PrivateSellers.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
          
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.PrivateSellers.Where(a => a.PrivateSellerId == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Dlt(int id)
        {
            var data = con.PrivateSellers.Find(id);
            con.PrivateSellers.Remove(data);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
