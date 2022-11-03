using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using s318344_Assignment1.Data;
using s318344_Assignment1.Models;

namespace s318344_Assignment1.Controllers
{
    public class InstrumentsController : Controller
    {
        private readonly s318344_Assignment1Context _context;

        public InstrumentsController(s318344_Assignment1Context context)
        {
            _context = context;
        }

        // GET: Instruments
        public async Task<IActionResult> Index()
        {
              return View(await _context.InstrumentModel.ToListAsync());
        }

        // GET: Instruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstrumentModel == null)
            {
                return NotFound();
            }

            var instrumentModel = await _context.InstrumentModel
                .FirstOrDefaultAsync(m => m.InstrumentId == id);
            if (instrumentModel == null)
            {
                return NotFound();
            }

            return View(instrumentModel);
        }

        // GET: Instruments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstrumentId,Make,Model")] InstrumentModel instrumentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrumentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrumentModel);
        }

        // GET: Instruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstrumentModel == null)
            {
                return NotFound();
            }

            var instrumentModel = await _context.InstrumentModel.FindAsync(id);
            if (instrumentModel == null)
            {
                return NotFound();
            }
            return View(instrumentModel);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstrumentId,Make,Model")] InstrumentModel instrumentModel)
        {
            if (id != instrumentModel.InstrumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrumentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentModelExists(instrumentModel.InstrumentId))
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
            return View(instrumentModel);
        }

        // GET: Instruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstrumentModel == null)
            {
                return NotFound();
            }

            var instrumentModel = await _context.InstrumentModel
                .FirstOrDefaultAsync(m => m.InstrumentId == id);
            if (instrumentModel == null)
            {
                return NotFound();
            }

            return View(instrumentModel);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InstrumentModel == null)
            {
                return Problem("Entity set 's318344_Assignment1Context.InstrumentModel'  is null.");
            }
            var instrumentModel = await _context.InstrumentModel.FindAsync(id);
            if (instrumentModel != null)
            {
                _context.InstrumentModel.Remove(instrumentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentModelExists(int id)
        {
          return _context.InstrumentModel.Any(e => e.InstrumentId == id);
        }
    }
}
