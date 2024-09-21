using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealtorsPortal.Models;

namespace RealtorsPortal.Controllers
{
    public class AgentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agents
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                return View(await _context.Agents.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
            
        }

        // GET: Agents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var agent = await _context.Agents
               .FirstOrDefaultAsync(m => m.Id == id);
                if (agent == null)
                {
                    return NotFound();
                }

                return View(agent);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            } 
        }

        // GET: Agents/Create
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

        // POST: Agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agent agent)
        {
            _context.Agents.Add(agent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Agents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var agent = await _context.Agents.FindAsync(id);
                if (agent == null)
                {
                    return NotFound();
                }
                return View(agent);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
          
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Agent agent)
        {
            _context.Agents.Update(agent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Agents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var agent = await _context.Agents
               .FirstOrDefaultAsync(m => m.Id == id);
                if (agent == null)
                {
                    return NotFound();
                }

                return View(agent);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agent = await _context.Agents.FindAsync(id);
            if (agent != null)
            {
                _context.Agents.Remove(agent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentExists(int id)
        {
            return _context.Agents.Any(e => e.Id == id);
        }
    }
}
