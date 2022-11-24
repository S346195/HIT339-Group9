using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group9_Assignment2.Data;
using Group9_Assignment2.Models;

namespace Group9_Assignment2.Controllers
{
    public class TutorsController : Controller
    {
        private readonly Group9_Assignment2Context _context;

        public TutorsController(Group9_Assignment2Context context)
        {
            _context = context;
        }

        // GET: Tutors
        public async Task<IActionResult> Index()
        {
              return View(await _context.TutorModel.ToListAsync());
        }

        // GET: Tutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TutorModel == null)
            {
                return NotFound();
            }

            var tutorModel = await _context.TutorModel
                .FirstOrDefaultAsync(m => m.TutorId == id);
            if (tutorModel == null)
            {
                return NotFound();
            }

            return View(tutorModel);
        }

        // GET: Tutors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TutorId,TutorName")] TutorModel tutorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tutorModel);
        }

        // GET: Tutors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TutorModel == null)
            {
                return NotFound();
            }

            var tutorModel = await _context.TutorModel.FindAsync(id);
            if (tutorModel == null)
            {
                return NotFound();
            }
            return View(tutorModel);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TutorId,TutorName")] TutorModel tutorModel)
        {
            if (id != tutorModel.TutorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorModelExists(tutorModel.TutorId))
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
            return View(tutorModel);
        }

        // GET: Tutors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TutorModel == null)
            {
                return NotFound();
            }

            var tutorModel = await _context.TutorModel
                .FirstOrDefaultAsync(m => m.TutorId == id);
            if (tutorModel == null)
            {
                return NotFound();
            }

            return View(tutorModel);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TutorModel == null)
            {
                return Problem("Entity set 's318344_Assignment1Context.TutorModel'  is null.");
            }
            var tutorModel = await _context.TutorModel.FindAsync(id);
            if (tutorModel != null)
            {
                _context.TutorModel.Remove(tutorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET: Tutors/Schedule/[id]

        public async Task<IActionResult> Schedule(int? id)
        {
            if (id == null || _context.TutorModel == null)
            {
                return View();
            }

            var tutorModel = await _context.TutorModel.Include(t => t.Lessons).SingleAsync(t => t.TutorId == id);
            
            if (tutorModel == null)
            {
                return NotFound();
            }

            return View(tutorModel);
        }

        public JsonResult GetLessons(int? id)
        {
            IQueryable<LessonModel> lessons = _context.LessonModel
                    .Include(l => l.Student)
                    .Include(l => l.Tutor)
                    .Include(l => l.LessonType)
                    ;



            if (id == null || _context.TutorModel == null)
            {
                //return everything
            } else
            {
                lessons = lessons.Where(l => l.TutorId == id);
            }



            if (lessons == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json("Error: No lessons found.");
            }

            var Data = lessons.Select(l => new {l.Student.StudentFullName, l.LessonDateTime, LessonFinish = l.LessonDateTime.AddMinutes(l.LessonType.LessonDuration) }).ToList();
            return Json(Data);
        }


        private bool TutorModelExists(int id)
        {
          return _context.TutorModel.Any(e => e.TutorId == id);
        }
    }
}
