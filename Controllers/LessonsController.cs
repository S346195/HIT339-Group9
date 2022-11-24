using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Group9_Assignment2.Data;
using Group9_Assignment2.Models;

namespace Group9_Assignment2.Controllers
{
    public class LessonsController : Controller
    {
        private readonly Group9_Assignment2Context _context;

        public LessonsController(Group9_Assignment2Context context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index(int? SelectedStudentId, string? order, string? orderBy, int? SelectedInstrumentId, int? SelectYear, int? SelectTerm, bool? OnlyUnpaid, int? SelectedTutorId)
        {
            var LessonsContext = from l in _context.LessonModel.Include(l => l.LessonType).Include(l=>l.Instrument).Include(l => l.Student).Include(l => l.Tutor).Include(l=>l.Letter) select l;
            
            List<int> Years = LessonsContext.Select(t => t.LessonYear).ToList();
            ViewData["Years"] = new SelectList(Years.Distinct(), "LessonYear");

            List<int> Terms = LessonsContext.Select(t => t.LessonTerm).ToList();
            ViewData["Terms"] = new SelectList(Terms.Distinct(), "LessonTerm");

            if (OnlyUnpaid == true)
            {
                LessonsContext = LessonsContext.Where(l => l.Paid == false);
            }

            if (SelectYear != null)
            {
                LessonsContext = LessonsContext.Where(l => l.LessonDateTime.Year == SelectYear);
            }


            if (SelectTerm != null)
            {
                LessonsContext = LessonsContext.Where(l => (l.LessonDateTime.Month + 2) / 3 == SelectTerm).OrderBy(l=>l.LessonDateTime);
            }


            switch (orderBy)
            {
                case "Student":

                    // Unable to apply sorting to a 'not mapped' column.
                    LessonsContext = order == "asc" ? LessonsContext.OrderBy(s => s.Student.StudentFirstName + " " + s.Student.StudentLastName) : LessonsContext.OrderByDescending(s => s.Student.StudentFirstName + " " + s.Student.StudentLastName);
                    break;
                case "Tutor":
                    LessonsContext = order == "asc" ? LessonsContext.OrderBy(s => s.Tutor.TutorName) : LessonsContext.OrderByDescending(s => s.Tutor.TutorName);
                    break;
                case "LessonType":
                    LessonsContext = order == "asc" ? LessonsContext.OrderBy(s => s.LessonType) : LessonsContext.OrderByDescending(s => s.LessonType);
                    break;
                case "LessonDateTime":
                    LessonsContext = order == "asc" ? LessonsContext.OrderBy(s => s.LessonDateTime) : LessonsContext.OrderByDescending(s => s.LessonDateTime);
                    break;

                case "Instrument":
                    LessonsContext = order == "asc" ? LessonsContext.OrderBy(s => s.Instrument.Make + " " + s.Instrument.Model) : LessonsContext.OrderByDescending(s => s.Instrument.Make + " " + s.Instrument.Model);
                    break;

                case "LessonTerm":
                    LessonsContext = order == "asc" ? LessonsContext.OrderBy(s => s.LessonDateTime.Month + 2 / 3) : LessonsContext.OrderByDescending(s => s.LessonDateTime.Month + 2 / 3);
                    break;

                case "LessonYear":
                    LessonsContext = order == "asc" ? LessonsContext.OrderBy(s => s.LessonDateTime.Year) : LessonsContext.OrderByDescending(s => s.LessonDateTime.Year);
                    break;
                case "Paid":
                    LessonsContext = order == "asc" ? LessonsContext.OrderBy(s => s.Paid) : LessonsContext.OrderByDescending(s => s.Paid);
                    break;
            
                default:
                    LessonsContext = LessonsContext.OrderByDescending(s => s.LessonId);
                    break;

            }

            ViewBag.order = order;
            ViewBag.orderBy = orderBy;
            ViewBag.SelectedStudentId = SelectedStudentId;
            ViewBag.SelectedTutorId = SelectedTutorId;
            ViewBag.SelectedLessonId = SelectedTutorId;


            if (SelectedStudentId != null)
            {
                LessonsContext = LessonsContext.Where(l => l.StudentId == SelectedStudentId);
            }

            if (SelectedTutorId != null)
            {
                LessonsContext = LessonsContext.Where(l => l.TutorId == SelectedTutorId);
            }

            if (SelectedInstrumentId != null)
            {
                LessonsContext = LessonsContext.Where(l => l.InstrumentId == SelectedInstrumentId);
            }

            return View(await LessonsContext.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LessonModel == null)
            {
                return NotFound();
            }

            var lessonModel = await _context.LessonModel
                .Include(l => l.LessonType)
                .Include(l => l.Student)
                .Include(l => l.Instrument)
                .Include(l => l.Tutor)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lessonModel == null)
            {
                return NotFound();
            }

            return View(lessonModel);
        }

        // GET: Lessons/Create
        public IActionResult Create(int? SelectedStudentID)
        {

            var SelectedStudent = _context.StudentModel.FirstOrDefault(s => s.StudentID == SelectedStudentID);

            if (SelectedStudent == null)
            {
                ViewData["StudentId"] = new SelectList(_context.Set<StudentModel>(), "StudentID", "StudentFullName");
            } else
            {
                ViewData["StudentId"] = new SelectList(_context.Set<StudentModel>(), "StudentID", "StudentFullName", SelectedStudentID);
            }


            ViewData["LessonTypeId"] = new SelectList(_context.Set<LessonTypeModel>(), "LessonTypeId", "LessonTypeFullName");
            ViewData["TutorId"] = new SelectList(_context.Set<TutorModel>(), "TutorId", "TutorName");
            ViewData["InstrumentId"] = new SelectList(_context.Set<InstrumentModel>(), "InstrumentId", "Instrument");


            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,StudentId,TutorId,LessonTypeId,InstrumentId,LessonDateTime,Paid")] LessonModel lessonModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonTypeId"] = new SelectList(_context.Set<LessonTypeModel>(), "LessonTypeId", "LessonTypeFullName");
            ViewData["StudentId"] = new SelectList(_context.Set<StudentModel>(), "StudentID", "StudentID", lessonModel.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Set<TutorModel>(), "TutorId", "TutorName", lessonModel.TutorId);
            ViewData["InstrumentId"] = new SelectList(_context.Set<InstrumentModel>(), "InstrumentId", "Instrument", lessonModel.InstrumentId);

            return View(lessonModel);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LessonModel == null)
            {
                return NotFound();
            }

            var lessonModel = await _context.LessonModel.FindAsync(id);
            if (lessonModel == null)
            {
                return NotFound();
            }
            ViewData["LessonTypeId"] = new SelectList(_context.Set<LessonTypeModel>(), "LessonTypeId", "LessonTypeFullName", lessonModel.LessonTypeId);
            ViewData["StudentId"] = new SelectList(_context.Set<StudentModel>(), "StudentID", "StudentFullName", lessonModel.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Set<TutorModel>(), "TutorId", "TutorName", lessonModel.TutorId);
            ViewData["InstrumentId"] = new SelectList(_context.Set<InstrumentModel>(), "InstrumentId", "Instrument", lessonModel.InstrumentId);

            return View(lessonModel);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,StudentId,TutorId,LessonTypeId,InstrumentId,LessonDateTime,Paid")] LessonModel lessonModel)
        {
            if (id != lessonModel.LessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonModelExists(lessonModel.LessonId))
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
            ViewData["LessonTypeId"] = new SelectList(_context.Set<LessonTypeModel>(), "LessonTypeId", "LessonTypeFullName", lessonModel.LessonTypeId);
            ViewData["StudentId"] = new SelectList(_context.Set<StudentModel>(), "StudentID", "PaymentContactNumber", lessonModel.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Set<TutorModel>(), "TutorId", "TutorName", lessonModel.TutorId);
            ViewData["InstrumentId"] = new SelectList(_context.Set<InstrumentModel>(), "InstrumentId", "Instrument", lessonModel.InstrumentId);

            return View(lessonModel);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LessonModel == null)
            {
                return NotFound();
            }

            var lessonModel = await _context.LessonModel
                .Include(l => l.LessonType)
                .Include(l => l.Student)
                .Include(l => l.Tutor)
                .Include(l => l.Instrument)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lessonModel == null)
            {
                return NotFound();
            }

            return View(lessonModel);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LessonModel == null)
            {
                return Problem("Entity set 's318344_Assignment1Context.LessonModel'  is null.");
            }
            var lessonModel = await _context.LessonModel.FindAsync(id);
            if (lessonModel != null)
            {
                _context.LessonModel.Remove(lessonModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SelectStudent(string SearchFirstname, string SearchSurname, string ReturnToAction)
        {

            var students = _context.StudentModel.AsEnumerable();

            if (!String.IsNullOrEmpty(SearchFirstname))
            {
                students = students.Where(s => s.StudentFirstName.Contains(SearchFirstname));
            }

            if (!String.IsNullOrEmpty(SearchSurname))
            {
                students = students.Where(s => s.StudentLastName.Contains(SearchSurname)).OrderBy(s=>s.StudentFirstName + " "+ s.StudentLastName);
            }

            ViewBag.ReturnTo = ReturnToAction;
            ViewBag.Students = students;

            return PartialView("_SelectStudent");
        }



        private bool LessonModelExists(int id)
        {
          return _context.LessonModel.Any(e => e.LessonId == id);
        }
    }
}
