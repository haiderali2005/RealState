using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class FrontendController : Controller
    {
        ApplicationDbContext con;
        public FrontendController(ApplicationDbContext _Con)
        {
            this.con = _Con;
        }
        public IActionResult Index(string search)
        {
            // Retrieve all properties from the database
            List<Property> properties = con.Properties.ToList();

            // Filter properties based on the search term if provided
            if (!string.IsNullOrEmpty(search))
            {
                properties = properties.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Pass the filtered or complete property list to the view
            ViewData["propertiez"] = properties;

            // Pass other necessary data to the view (like team and contact information)
            ViewData["teamz"] = con.OurTeam.ToList();
            ViewData["contactz"] = con.ContactUs.ToList();

            return View();
        }

        public IActionResult Service()
        {
            List<Contactus> contact = con.ContactUs.ToList();
            ViewData["contactz"] = contact;
            return View();
        }
        public IActionResult About()
        {
            List<Team> teams = con.OurTeam.ToList();
            ViewData["teamz"] = teams;
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contactus contact)
        {
            con.ContactUs.Add(contact);
            con.SaveChanges();
            TempData["contact"] = "SUCCESSFULLY SUBMITTED";
            return View();
        }

        public IActionResult Properties()
        {
            List<Property> properties2 = con.Properties.ToList();
            ViewData["propertiez2"] = properties2;
            return View();
        }
        public IActionResult PropertyDetail(int id)
        {
            var data = con.Properties.Include(a => a.Agent).Include(p => p.PrivateSeller).Where(i => i.Property_Id == id).ToList();
            return View(data);
        }
    }
}
