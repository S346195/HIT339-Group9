using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group9_Assignment2.Data;
using Group9_Assignment2.Models;
using System.Net.Mail;
using System.Net;

namespace Group9_Assignment2_HIT339.Controllers
{
    public class LettersController : Controller
    {
        private readonly Group9_Assignment2Context _context;

        public LettersController(Group9_Assignment2Context context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index(int? StudentId, int? LetterId, int? LessonId, string? order, string? orderBy)
        {
            var letters = _context.LetterModel
                .Include(l => l.Student)
                .Include(l => l.Lessons)
                .Where(l => l.StudentId == StudentId || StudentId == null)
                .Where(l=>l.Lessons.Where(s=>s.LessonId == LessonId).Count() > 0 || LessonId == null)
                .Where(l => l.LetterId == LetterId || LetterId == null)
                ;



            switch (orderBy)
            {
                case "created":
                    letters = order == "asc" ? letters.OrderBy(s => s.LetterCreationDate) : letters.OrderByDescending(s => s.LetterCreationDate);
                    break;
                case "reference":
                    letters = order == "asc" ? letters.OrderBy(s => (int) (DateTime.Today.Year + s.LetterId)) : letters.OrderByDescending(s => (int) (DateTime.Today.Year + s.LetterId));
                    break;
                case "student":
                    letters = order == "asc" ? letters.OrderBy(s => s.Student.StudentFirstName + " " + s.Student.StudentLastName) : letters.OrderByDescending(s => s.Student.StudentFirstName + " " + s.Student.StudentLastName);
                    break;
                case "sent":
                    letters = order == "asc" ? letters.OrderBy(s => s.Student.PaymentContactEmail) : letters.OrderByDescending(s => s.Student.PaymentContactEmail);
                    break;
                default:
                    letters = letters.OrderByDescending(s => s.LetterCreationDate);
                    break;



            }

            ViewBag.StudentId = StudentId;
            ViewBag.LetterId = LetterId;
            ViewBag.order = order;

            return View(await letters.ToListAsync()); ;
        }

        //GET: Letters/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LessonModel == null)
            {
                return NotFound();
            }

            var letter = await _context.LetterModel
                .Include(l => l.Lessons)
                .Include(l => l.Student)

                .FirstOrDefaultAsync(m => m.LetterId == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // GET: Letters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LessonModel == null)
            {
                return NotFound();
            }

            var Letter = await _context.LetterModel
                .Include(l => l.Student)
                .Include(l => l.Lessons)
                .FirstOrDefaultAsync(m => m.LetterId == id);
            if (Letter == null)
            {
                return NotFound();
            }

            return View(Letter);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LetterModel == null)
            {
                return Problem("Entity set 's318344_Assignment1Context.LessonModel'  is null.");
            }
            var Letter = await _context.LetterModel.Include(l => l.Lessons).Include(l=>l.Student).Where(l=>l.LetterId == id).FirstAsync();
            if (Letter != null)
            {
                foreach (LessonModel lesson in Letter.Lessons)
                {
                    lesson.LetterId = null;
                }
                _context.LetterModel.Remove(Letter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //POST: Letters/Generate
        //Action receives a collection of lesson ids submitted by the user from the /Lessons/Index page.
        //This action converts the IFormCollection to a list to be passed to /Letters/Preview and /Letters/Send.
        //The view return allows the user to define the content of the email.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Generate(IFormCollection SelectedLessons)
        {
            if (_context.LessonModel == null || SelectedLessons == null)
            {
                return NotFound();
            }

            //The last key-value pair will be the anti-forgery token.
            IEnumerable<string> lessonIDsEnum = SelectedLessons.Keys.SkipLast(1);

            //convert enum of strings to list of ints
            List<int> IDs = lessonIDsEnum.ToList().Select(s => int.Parse(s)).ToList();

            TempData["SelectedLessonIds"] = IDs;

            GenerateLetterViewModel TemplateLetterContent = new GenerateLetterViewModel {};

            return View(TemplateLetterContent);
        }

        //POST: Letters/Preview

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Preview(GenerateLetterViewModel LetterTemplate)
        {
            if (_context.LessonModel == null || LetterTemplate == null)
            {
                return NotFound();
            }

            Int32[] SelectedLessonIds = (Int32[])TempData["SelectedLessonIds"];

            List<LetterModel> Letters = CreateLetters(LetterTemplate.LetterContent, SelectedLessonIds);

            TempData["SelectedLessonIds"] = SelectedLessonIds;
            TempData["LetterContent"] = LetterTemplate.LetterContent;



            return View(Letters);
        }

        protected List<LetterModel> CreateLetters(string LetterContent, Int32[] LessonIds)
        {

            //collection of lessons for which to produce letters for
            var lessons = _context.LessonModel
                .Include(l => l.Student)
                .Include(l => l.Tutor)
                .Include(l => l.LessonType)
                .Where(l => LessonIds.Contains(l.LessonId))
                .ToList()
                .OrderBy(l => l.Student.StudentFullName)
                .GroupBy(l => l.Student)
                ;

            List<LetterModel> Letters = new List<LetterModel>();

            foreach (var lesson in lessons)
            {
                
                LetterModel letter =
                    new LetterModel
                    {
                        LetterCreationDate = DateTime.Today,
                        StudentId = lesson.Key.StudentID,
                        Student = lesson.Key,
                        Lessons = lesson.ToList(),
                        RawLetterContent = LetterContent
                    };

                Letters.Add(letter);
            }

            return Letters;
        }

        //POST via AJAX: Letters/Send
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send()
        {
            Int32[] SelectedLessonIds = (Int32[])TempData["SelectedLessonIds"];
            string LetterContent = (string)TempData["LetterContent"];

            TempData["SelectedLessonIds"] = SelectedLessonIds;
            TempData["LetterContent"] = LetterContent;

            //If letter template is null it is assumed the user has arrived via lessons -> generate -> send so check for letters in temp data else return error.
            if (LetterContent == null && SelectedLessonIds == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Invalid request.");

            } else {

                List<LetterModel> Letters = CreateLetters(LetterContent, SelectedLessonIds);

                //Test recipient email account used to avoid emails being sent to real people.
                //var receiverEmail = new MailAddress(letter.Student.PaymentContactEmail, letter.Student.StudentFullName);
                var receiverEmail = new MailAddress("totallycmyc@gmail.com", "Test");

                //Using Rhys' mail server for sending because Google no longer allows 'insecure' access methods
                var senderEmail = new MailAddress("cmyc@serverforthesakeofit.com", "CMYC");
                var password = "What is SMTP?";

                var smtp = new SmtpClient
                {
                    Host = "mail.serverforthesakeofit.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password),


                };

                Dictionary<string, Exception> errors = new Dictionary<string, Exception>();
                List<string> successful = new List<string>();

                foreach (LetterModel letter in Letters) {

                    try
                    {

                        var sub = letter.letterReference + " - CMYC Communication";
                        var body = letter._LetterContent;

                        using (MailMessage mess = new MailMessage(senderEmail, receiverEmail)
                        {

                            IsBodyHtml = true,
                            Subject = sub,
                            Body = body
                        })
                        {
                            smtp.Send(mess);
                            successful.Add(letter.letterReference);

                            //Successful email sent, save letter to database and reference against lesson.
                            foreach (LessonModel lesson in letter.Lessons)
                            {

                                lesson.LetterId = letter.LetterId;
                            }
                            _context.LetterModel.Add(letter);
                            _context.SaveChanges();

                        }
                    }
                    catch (Exception ex)
                    {
                        //This doesn't trigger when an email address is incorrect, only when the server fails to send.
                        errors.Add(letter.letterReference, ex);
                    }
                }

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(
                    new
                    {
                      sent = successful,
                      failed = string.Join(Environment.NewLine, errors)
                    });
            }
        }

        public ActionResult getLetterTemplate()
        { 
            //The following fields could be calculated directly in the view, however they are added in the controller to keep the related c# together.

            // Returns a value between 0 and 5 indicating the term according to equal 3 month periods.
            ViewBag.CurrentTerm = (int) (DateTime.Today.Month + 2) / 3;
            // Returns the start date of the first month each term.
            ViewBag.CurrentTermStart = new DateOnly(DateTime.Today.Year, ViewBag.CurrentTerm == 1 ? 1 : (ViewBag.CurrentTerm - 1) * 3, 1);
            // Returns one month from the current date.
            ViewBag.PaymentDue = DateOnly.FromDateTime(DateTime.Today.AddMonths(1));
    

            return PartialView("_LetterTemplate");
        }
    }



}
