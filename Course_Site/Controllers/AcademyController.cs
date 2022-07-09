using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Course_Site.Models;
using System.Diagnostics;
using Course.Shared;
using Course_Site.Data;

using Microsoft.Extensions.Logging;


using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Course_Site.Controllers
{
    public class AcademyController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Academy academy;
        public AcademyController(ILogger<HomeController> logger, Academy academy)
        {
            _logger = logger;
            
            this.academy = academy;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await academy.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Faculty)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await academy.Students.FirstOrDefaultAsync(s => s.StudentID == id);
            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                try
                {
                    await academy.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    [Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    academy.Add(student);
                    await academy.SaveChangesAsync();
                    return RedirectToAction(nameof(School));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(student);
        }
        public IActionResult School()
        {
            return View(academy.Students.ToList());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
