using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class PropertyController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment env;
        public PropertyController(ApplicationDbContext con, IWebHostEnvironment _env)
        {
            this._context = con;
            this.env = _env;

        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _context.Properties.Include(a => a.Agent).Include(s => s.PrivateSeller).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }         
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                List<Agent> agent = _context.Agents.ToList();
                ViewData["agentz"] = agent;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }  
        }
        [HttpPost]
        public IActionResult Create(Property pro,IFormFile Image)
        {
            string filename = Path.GetFileName(Image.FileName);
            string filepath = Path.Combine(env.WebRootPath, "Propertyimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            Image.CopyTo(fs);
            pro.Image = filename;
            _context.Properties.Add(pro);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                List<Agent> agent = _context.Agents.ToList();
                ViewData["agentz"] = agent;
                var data = _context.Properties.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }   
        }
        [HttpPost]
        public IActionResult Edit(Property pro,IFormFile Image)
        {
            string filename = Path.GetFileName(Image.FileName);
            string filepath = Path.Combine(env.WebRootPath, "Propertyimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            Image.CopyTo(fs);
            pro.Image = filename;
            _context.Properties.Update(pro);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _context.Properties.Include(s => s.Agent).Include(s => s.PrivateSeller).Where(a => a.Property_Id == id).FirstOrDefault();
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
                var data = _context.Properties.Include(s => s.Agent).Include(s => s.PrivateSeller).Where(a => a.Property_Id == id).FirstOrDefault();
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
            var data = _context.Properties.Find(id);
            _context.Properties.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
