using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group9_Assignment2.Data;
using Group9_Assignment2.Models;

namespace Group9_Assignment2.Controllers
{
    public class LessonTypesController : Controller
    {
        private readonly Group9_Assignment2Context _context;

        public LessonTypesController(Group9_Assignment2Context context)
        {
            _context = context;
        }

        // GET: LessonTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.LessonTypeModel.ToListAsync());
        }

        // GET: LessonTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LessonTypeModel == null)
            {
                return NotFound();
            }

            var lessonTypeModel = await _context.LessonTypeModel
                .FirstOrDefaultAsync(m => m.LessonTypeId == id);
            if (lessonTypeModel == null)
            {
                return NotFound();
            }

            return View(lessonTypeModel);
        }

        // GET: LessonTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LessonTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonTypeId,LessonType,LessonDuration,LessonCost")] LessonTypeModel lessonTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonTypeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lessonTypeModel);
        }

        // GET: LessonTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LessonTypeModel == null)
            {
                return NotFound();
            }

            var lessonTypeModel = await _context.LessonTypeModel.FindAsync(id);
            if (lessonTypeModel == null)
            {
                return NotFound();
            }
            return View(lessonTypeModel);
        }

        // POST: LessonTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonTypeId,LessonType,LessonDuration,LessonCost")] LessonTypeModel lessonTypeModel)
        {
            if (id != lessonTypeModel.LessonTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonTypeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonTypeModelExists(lessonTypeModel.LessonTypeId))
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
            return View(lessonTypeModel);
        }

        // GET: LessonTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LessonTypeModel == null)
            {
                return NotFound();
            }

            var lessonTypeModel = await _context.LessonTypeModel
                .FirstOrDefaultAsync(m => m.LessonTypeId == id);
            if (lessonTypeModel == null)
            {
                return NotFound();
            }

            return View(lessonTypeModel);
        }

        // POST: LessonTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LessonTypeModel == null)
            {
                return Problem("Entity set 's318344_Assignment1Context.LessonTypeModel'  is null.");
            }
            var lessonTypeModel = await _context.LessonTypeModel.FindAsync(id);
            if (lessonTypeModel != null)
            {
                _context.LessonTypeModel.Remove(lessonTypeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonTypeModelExists(int id)
        {
          return _context.LessonTypeModel.Any(e => e.LessonTypeId == id);
        }
    }
}
