using Microsoft.AspNetCore.Mvc;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class TeamController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment env;
        public TeamController(ApplicationDbContext con, IWebHostEnvironment _env)
        {
            this._context = con;
            this.env = _env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _context.OurTeam.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            } 
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _context.OurTeam.Where(a => a.Id == id).FirstOrDefault();
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
                var data = _context.OurTeam.Where(a => a.Id == id).FirstOrDefault();
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
            var data = _context.OurTeam.Find(id);
            _context.OurTeam.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
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
        [HttpPost]
        public IActionResult Create(Team _team, IFormFile Image)
        {
            string filename = Path.GetFileName(Image.FileName);
            string filepath = Path.Combine(env.WebRootPath, "Teampics", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            Image.CopyTo(fs);
            _team.Image = filename;
            _context.OurTeam.Add(_team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _context.OurTeam.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }    
        }
        [HttpPost]
        public IActionResult Edit(Team _team, IFormFile Image)
        {
            string filename = Path.GetFileName(Image.FileName);
            string filepath = Path.Combine(env.WebRootPath, "Teampics", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            Image.CopyTo(fs);
            _team.Image = filename;
            _context.OurTeam.Update(_team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
