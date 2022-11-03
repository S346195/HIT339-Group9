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
    public class GendersController : Controller
    {
        private readonly s318344_Assignment1Context _context;

        public GendersController(s318344_Assignment1Context context)
        {
            _context = context;
        }

        // GET: Genders
        public async Task<IActionResult> Index()
        {
              return View(await _context.GenderModel.ToListAsync());
        }

        // GET: Genders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GenderModel == null)
            {
                return NotFound();
            }

            var genderModel = await _context.GenderModel
                .FirstOrDefaultAsync(m => m.GenderId == id);
            if (genderModel == null)
            {
                return NotFound();
            }

            return View(genderModel);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenderId,Gender")] GenderModel genderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genderModel);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GenderModel == null)
            {
                return NotFound();
            }

            var genderModel = await _context.GenderModel.FindAsync(id);
            if (genderModel == null)
            {
                return NotFound();
            }
            return View(genderModel);
        }

        // POST: Genders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenderId,Gender")] GenderModel genderModel)
        {
            if (id != genderModel.GenderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderModelExists(genderModel.GenderId))
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
            return View(genderModel);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GenderModel == null)
            {
                return NotFound();
            }

            var genderModel = await _context.GenderModel
                .FirstOrDefaultAsync(m => m.GenderId == id);
            if (genderModel == null)
            {
                return NotFound();
            }

            return View(genderModel);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GenderModel == null)
            {
                return Problem("Entity set 's318344_Assignment1Context.GenderModel'  is null.");
            }
            var genderModel = await _context.GenderModel.FindAsync(id);
            if (genderModel != null)
            {
                _context.GenderModel.Remove(genderModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderModelExists(int id)
        {
          return _context.GenderModel.Any(e => e.GenderId == id);
        }
    }
}
