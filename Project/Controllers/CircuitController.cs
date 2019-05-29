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
    public class CircuitController : Controller
    {
        private readonly EFContext _context;

        public CircuitController(EFContext context)
        {
            _context = context;
        }

        // GET: Circuit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Circuits.ToListAsync());
        }

        // GET: Circuit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits
                .FirstOrDefaultAsync(m => m.CircuitID == id);
            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }

        // GET: Circuit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Circuit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CircuitID,NaamCircuit,Land")] Circuit circuit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(circuit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(circuit);
        }

        // GET: Circuit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit == null)
            {
                return NotFound();
            }
            return View(circuit);
        }

        // POST: Circuit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CircuitID,NaamCircuit,Land")] Circuit circuit)
        {
            if (id != circuit.CircuitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(circuit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircuitExists(circuit.CircuitID))
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
            return View(circuit);
        }

        // GET: Circuit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits
                .FirstOrDefaultAsync(m => m.CircuitID == id);
            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }

        // POST: Circuit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var circuit = await _context.Circuits.FindAsync(id);
            _context.Circuits.Remove(circuit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CircuitExists(int id)
        {
            return _context.Circuits.Any(e => e.CircuitID == id);
        }
    }
}
