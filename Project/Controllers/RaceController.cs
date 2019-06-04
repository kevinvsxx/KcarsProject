using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RaceController : Controller
    {

        private readonly EFContext _context;


        public RaceController(EFContext context)
        {
            _context = context;
        }

        // GET: Race
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Races.Include(r => r.Circuit);
            return View(await eFContext.ToListAsync());
        }

        // GET: Race/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races
                .Include(r => r.Circuit)
                .FirstOrDefaultAsync(m => m.RaceID == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // GET: Race/Create
        public IActionResult Create()
        {
            ViewData["CircuitID"] = new SelectList(_context.Circuits, "CircuitID", "NaamCircuit");
            return View();
        }

        // POST: Race/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RaceID,RaceDag,CircuitID")] Race race)
        {
            if (ModelState.IsValid)
            {
                _context.Add(race);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircuitID"] = new SelectList(_context.Circuits, "CircuitID", "NaamCircuit", race.CircuitID);
            return View(race);
        }

        // GET: Race/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }
            ViewData["CircuitID"] = new SelectList(_context.Circuits, "CircuitID", "NaamCircuit", race.CircuitID);
            return View(race);
        }

        // POST: Race/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RaceID,RaceDag,CircuitID")] Race race)
        {
            if (id != race.RaceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(race);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceExists(race.RaceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircuitID"] = new SelectList(_context.Circuits, "CircuitID", "NaamCircuit", race.CircuitID);
            return View(race);
        }

        // GET: Race/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races
                .Include(r => r.Circuit)
                .FirstOrDefaultAsync(m => m.RaceID == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // POST: Race/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var race = await _context.Races.FindAsync(id);
            _context.Races.Remove(race);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceExists(int id)
        {
            return _context.Races.Any(e => e.RaceID == id);
        }
    }
}
