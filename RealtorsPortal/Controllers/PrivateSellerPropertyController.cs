using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class PrivateSellerPropertyController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment env;
        public PrivateSellerPropertyController(ApplicationDbContext con, IWebHostEnvironment _env)
        {
            this._context = con;
            this.env = _env;

        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("mypvtuser") != null)
            {
                List<PrivateSeller> privseller = _context.PrivateSellers.ToList();
                ViewData["privatesellerz"] = privseller;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "PrivateSeller");
            }
           
        }
        [HttpPost]
        public IActionResult Create(Property pro, IFormFile Image)
        {
            string filename = Path.GetFileName(Image.FileName);
            string filepath = Path.Combine(env.WebRootPath, "Propertyimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            Image.CopyTo(fs);
            pro.Image = filename;
            _context.Properties.Add(pro);
            _context.SaveChanges();
            return RedirectToAction("Properties","Frontend");
        }
    }
}
