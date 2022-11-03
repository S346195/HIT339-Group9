using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using s318344_Assignment1.Data;
using s318344_Assignment1.Models;

namespace Group9_Assignment2_HIT339.Controllers
{
    public class LettersController : Controller
    {
        private readonly s318344_Assignment1Context _context;

        public LettersController(s318344_Assignment1Context context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
            return View(await _context.LessonModel.ToListAsync());
        }

        //POST: Letters/Generate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(IFormCollection SelectedLessons)
        {
            if (_context.LessonModel == null)
            {
                return Problem("Entity set 's318344_Assignment1Context.LessonModel'  is null.");
            }

            if (SelectedLessons == null)
            {
                return Problem("Please select atlease one lesson to generate a letter for.");
            }

            //The last key-value pair will be the anti-forgery token.
            IEnumerable<string> lessonIDsEnum = SelectedLessons.Keys.SkipLast(1);

            //convert enum of strings to list of ints
            List<int> lessonIds = lessonIDsEnum.ToList().Select(s => int.Parse(s)).ToList();

            //collection of lessons for which to produce letters for
            var lessons = _context.LessonModel
                .Include(l => l.Student)
                .Include(l => l.Tutor)
                .Include(l=> l.LessonType)
                .Where(l => lessonIds.Contains(l.LessonId))
                .ToList()
                .GroupBy(l => l.Student);

            List<LetterModel> Letters = new List<LetterModel>(); 
            
            foreach (var lesson in lessons)
            {
                LetterModel letter =
                    new LetterModel {
                        LetterCreationDate = DateTime.Today,
                        StudentId = lesson.Key.StudentID,
                        Student = lesson.Key,
                        Lessons = lesson.ToList()
                    };

                Letters.Add(letter);
            }

            ViewBag.Letters = Letters.OrderBy(l=>l.Student.StudentFullName) ;


            return View();
        }

        public IActionResult Preview()
        {
            StudentModel stud = _context.StudentModel
                .Include(s=>s.Lessons)
                .First();

            var les = _context.LessonModel
                .Include(l => l.Tutor)
                .Include(l => l.LessonType)
             .Where(l => l.StudentId == stud.StudentID);

            LetterModel letter = new LetterModel
            {
                LetterCreationDate = DateTime.Today,
                StudentId = stud.StudentID,
                Student = stud,
                Lessons = les.ToList(),

                BeginningComment = "Test 123",
                EmailSignature = "Rhys Lewis",
                BankAccountName = "CMYC",
                BankName = "ING",
                BankAccountBSB = "095211",
                BankAccountNumber = "9874682"

            };

            return View(letter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: Letters/Confirmation
        public async Task<IActionResult> Confirmation(IFormCollection Letters)
        {
            return View();
        }
    }
}
