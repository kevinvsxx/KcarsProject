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
    public class AutoRaceController : Controller
    {
        private readonly EFContext _context;

        public AutoRaceController(EFContext context)
        {
            _context = context;
        }

        // GET: AutoRaces
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.AutoRaces.Include(a => a.Auto).Include(a => a.Race);
            return View(await eFContext.ToListAsync());
        }

        // GET: AutoRaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoRace = await _context.AutoRaces
                .Include(a => a.Auto)
                .Include(a => a.Race)
                .FirstOrDefaultAsync(m => m.AutoRaceID == id);
            if (autoRace == null)
            {
                return NotFound();
            }

            return View(autoRace);
        }

        // GET: AutoRaces/Create
        public IActionResult Create()
        {
            ViewData["AutoID"] = new SelectList(_context.Autos, "AutoID", "Merk");
            ViewData["RaceID"] = new SelectList(_context.Races, "RaceID", "RaceDag");
            return View();
        }

        // POST: AutoRaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoRaceID,AutoID,RaceID")] AutoRace autoRace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoRace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoID"] = new SelectList(_context.Autos, "AutoID", "Merk", autoRace.AutoID);
            ViewData["RaceID"] = new SelectList(_context.Races, "RaceID", "RaceID", autoRace.RaceID);
            return View(autoRace);
        }

        // GET: AutoRaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoRace = await _context.AutoRaces.FindAsync(id);
            if (autoRace == null)
            {
                return NotFound();
            }
            ViewData["AutoID"] = new SelectList(_context.Autos, "AutoID", "Merk", autoRace.AutoID);
            ViewData["RaceID"] = new SelectList(_context.Races, "RaceID", "RaceID", autoRace.RaceID);
            return View(autoRace);
        }

        // POST: AutoRaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoRaceID,AutoID,RaceID")] AutoRace autoRace)
        {
            if (id != autoRace.AutoRaceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoRace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoRaceExists(autoRace.AutoRaceID))
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
            ViewData["AutoID"] = new SelectList(_context.Autos, "AutoID", "Merk", autoRace.AutoID);
            ViewData["RaceID"] = new SelectList(_context.Races, "RaceID", "RaceID", autoRace.RaceID);
            return View(autoRace);
        }

        // GET: AutoRaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoRace = await _context.AutoRaces
                .Include(a => a.Auto)
                .Include(a => a.Race)
                .FirstOrDefaultAsync(m => m.AutoRaceID == id);
            if (autoRace == null)
            {
                return NotFound();
            }

            return View(autoRace);
        }

        // POST: AutoRaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoRace = await _context.AutoRaces.FindAsync(id);
            _context.AutoRaces.Remove(autoRace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoRaceExists(int id)
        {
            return _context.AutoRaces.Any(e => e.AutoRaceID == id);
        }
    }
}
