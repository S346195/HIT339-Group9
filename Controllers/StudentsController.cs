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
    public class StudentsController : Controller
    {
        private readonly s318344_Assignment1Context _context;

        public StudentsController(s318344_Assignment1Context context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string? order, string? orderBy)
        {
            var students = from s in _context.StudentModel select s;
            students = students.Include(s => s.Gender);

            ViewBag.order = String.IsNullOrEmpty(order) ? "desc" : order;
            ViewBag.orderBy = String.IsNullOrEmpty(orderBy) ? "LastName" : orderBy;

            switch (orderBy)
            {
                case "StudentID":
                    students = order == "asc" ? students.OrderBy(s => s.StudentID) : students.OrderByDescending(s => s.StudentID);
                    break;
                case "StudentFirstName":
                    students = order == "asc" ? students.OrderBy(s => s.StudentFirstName) : students.OrderByDescending(s => s.StudentFirstName);
                    break;
                case "StudentLastName":
                    students = order == "asc" ? students.OrderBy(s => s.StudentLastName) : students.OrderByDescending(s => s.StudentLastName);
                    break;
                case "DOB":
                    students = order == "asc" ? students.OrderBy(s => s.DOB) : students.OrderByDescending(s => s.DOB);
                    break;
                case "Age":
                    students = order == "asc" ? students.OrderBy(s => s.DOB) : students.OrderByDescending(s => s.DOB);
                    break;
                case "Gender":
                    students = order == "asc" ? students.OrderBy(s => s.Gender) : students.OrderByDescending(s => s.Gender);
                    break;
                case "GuardianName":
                    students = order == "asc" ? students.OrderBy(s => s.GuardianName) : students.OrderByDescending(s => s.GuardianName);
                    break;

                case "PaymentContactEmail":
                    students = order == "asc" ? students.OrderBy(s => s.PaymentContactEmail) : students.OrderByDescending(s => s.PaymentContactEmail);
                    break;
                case "PaymentContactNumber":
                    students = order == "asc" ? students.OrderBy(s => s.PaymentContactNumber) : students.OrderByDescending(s => s.PaymentContactNumber);
                    break;

                default:
                    students = students.OrderByDescending(s => s.StudentLastName);
                    break;

            }


            ViewBag.order = order;
            ViewBag.orderBy = orderBy;

            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentModel == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel
                .Include(s => s.Gender)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.GenderModel, "GenderId", "Gender");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentFirstName,StudentLastName,DOB,GenderId,GuardianName,PaymentContactEmail,PaymentContactNumber")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.GenderModel, "GenderId", "Gender", studentModel.GenderId);
            return View(studentModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentModel == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.GenderModel, "GenderId", "Gender", studentModel.GenderId);
            return View(studentModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,StudentFirstName,StudentLastName,DOB,GenderId,GuardianName,PaymentContactEmail,PaymentContactNumber")] StudentModel studentModel)
        {
            if (id != studentModel.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentModelExists(studentModel.StudentID))
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
            ViewData["GenderId"] = new SelectList(_context.GenderModel, "GenderId", "Gender", studentModel.GenderId);
            return View(studentModel);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentModel == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel
                .Include(s => s.Gender)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentModel == null)
            {
                return Problem("Entity set 's318344_Assignment1Context.StudentModel'  is null.");
            }
            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel != null)
            {
                _context.StudentModel.Remove(studentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentModelExists(int id)
        {
          return _context.StudentModel.Any(e => e.StudentID == id);
        }
    }
}
