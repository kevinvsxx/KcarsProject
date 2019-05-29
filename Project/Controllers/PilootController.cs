using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class PilootController : Controller
    {
        private readonly EFContext _context;

        public PilootController(EFContext context)
        {
            _context = context;
        }

        // GET: Piloots
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Piloots.Include(p => p.Auto);
            return View(await eFContext.ToListAsync());
        }

        // GET: Piloots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloot = await _context.Piloots
                .Include(p => p.Auto)
                .FirstOrDefaultAsync(m => m.PilootID == id);
            if (piloot == null)
            {
                return NotFound();
            }

            return View(piloot);
        }

        // GET: Piloots/Create
        public IActionResult Create()
        {
            ViewData["AutoID"] = new SelectList(_context.Autos, "AutoID", "Merk");
            return View();
        }

        // POST: Piloots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PilootID,Naam,Voornaam,AutoID")] Piloot piloot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piloot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoID"] = new SelectList(_context.Autos, "AutoID", "Merk", piloot.AutoID);
            return View(piloot);
        }

        // GET: Piloots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloot = await _context.Piloots.FindAsync(id);
            if (piloot == null)
            {
                return NotFound();
            }
            ViewData["AutoID"] = new SelectList(_context.Autos, "AutoID", "Merk", piloot.AutoID);
            return View(piloot);
        }

        // POST: Piloots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PilootID,Naam,Voornaam,AutoID")] Piloot piloot)
        {
            if (id != piloot.PilootID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piloot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilootExists(piloot.PilootID))
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
            ViewData["AutoID"] = new SelectList(_context.Autos, "AutoID", "Merk", piloot.AutoID);
            return View(piloot);
        }

        // GET: Piloots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloot = await _context.Piloots
                .Include(p => p.Auto)
                .FirstOrDefaultAsync(m => m.PilootID == id);
            if (piloot == null)
            {
                return NotFound();
            }

            return View(piloot);
        }

        // POST: Piloots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piloot = await _context.Piloots.FindAsync(id);
            _context.Piloots.Remove(piloot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilootExists(int id)
        {
            return _context.Piloots.Any(e => e.PilootID == id);
        }
    }
}
