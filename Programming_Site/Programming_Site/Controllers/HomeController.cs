using Microsoft.AspNetCore.Mvc;
using Programming_Site.Models;
using System.Diagnostics;
using Course.Shared;

using System.Linq;

namespace Programming_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Programming_CoursesContext db;

        public HomeController(ILogger<HomeController> logger, Programming_CoursesContext db)
        {
            _logger = logger;
            this.db = db;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inner_Page()
        {
            return View();
        }
        public IActionResult Portfolio_Details()
        {
            return View();
        }
        
        public IActionResult Courses()
        {
            IEnumerable<ProgrammingCourse> courses = db.ProgrammingCourses.ToArray();
            return View(courses);
        }
        public IActionResult GetCourse(string? course)
        {
            if (course == null)
            {
                return NotFound();
            }

            IEnumerable<ProgrammingCourse> model = db.ProgrammingCourses.Where(x => x.CourseName.Contains(course)).ToList();

            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}