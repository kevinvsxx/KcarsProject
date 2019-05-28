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
    public class BestellingArtikelsController : Controller
    {
        private readonly EFContext _context;

        public BestellingArtikelsController(EFContext context)
        {
            _context = context;
        }

        // GET: BestellingArtikels
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.BestellingArtikels.Include(b => b.Artikel).Include(b => b.Bestelling);
            return View(await eFContext.ToListAsync());
        }

        // GET: BestellingArtikels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestellingArtikel = await _context.BestellingArtikels
                .Include(b => b.Artikel)
                .Include(b => b.Bestelling)
                .FirstOrDefaultAsync(m => m.BestellingArtikelID == id);
            if (bestellingArtikel == null)
            {
                return NotFound();
            }

            return View(bestellingArtikel);
        }

        // GET: BestellingArtikels/Create
        public IActionResult Create()
        {
            ViewData["ArtikelID"] = new SelectList(_context.Artikels, "ArtikelID", "Naam");
            ViewData["BestellingID"] = new SelectList(_context.Bestellingen, "BestellingID", "BestellingID");
            return View();
        }

        // POST: BestellingArtikels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BestellingArtikelID,BestellingID,ArtikelID")] BestellingArtikel bestellingArtikel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bestellingArtikel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtikelID"] = new SelectList(_context.Artikels, "ArtikelID", "Naam", bestellingArtikel.ArtikelID);
            ViewData["BestellingID"] = new SelectList(_context.Bestellingen, "BestellingID", "BestellingID", bestellingArtikel.BestellingID);
            return View(bestellingArtikel);
        }

        // GET: BestellingArtikels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestellingArtikel = await _context.BestellingArtikels.FindAsync(id);
            if (bestellingArtikel == null)
            {
                return NotFound();
            }
            ViewData["ArtikelID"] = new SelectList(_context.Artikels, "ArtikelID", "Naam", bestellingArtikel.ArtikelID);
            ViewData["BestellingID"] = new SelectList(_context.Bestellingen, "BestellingID", "BestellingID", bestellingArtikel.BestellingID);
            return View(bestellingArtikel);
        }

        // POST: BestellingArtikels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BestellingArtikelID,BestellingID,ArtikelID")] BestellingArtikel bestellingArtikel)
        {
            if (id != bestellingArtikel.BestellingArtikelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bestellingArtikel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BestellingArtikelExists(bestellingArtikel.BestellingArtikelID))
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
            ViewData["ArtikelID"] = new SelectList(_context.Artikels, "ArtikelID", "Naam", bestellingArtikel.ArtikelID);
            ViewData["BestellingID"] = new SelectList(_context.Bestellingen, "BestellingID", "BestellingID", bestellingArtikel.BestellingID);
            return View(bestellingArtikel);
        }

        // GET: BestellingArtikels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestellingArtikel = await _context.BestellingArtikels
                .Include(b => b.Artikel)
                .Include(b => b.Bestelling)
                .FirstOrDefaultAsync(m => m.BestellingArtikelID == id);
            if (bestellingArtikel == null)
            {
                return NotFound();
            }

            return View(bestellingArtikel);
        }

        // POST: BestellingArtikels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bestellingArtikel = await _context.BestellingArtikels.FindAsync(id);
            _context.BestellingArtikels.Remove(bestellingArtikel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BestellingArtikelExists(int id)
        {
            return _context.BestellingArtikels.Any(e => e.BestellingArtikelID == id);
        }
    }
}
