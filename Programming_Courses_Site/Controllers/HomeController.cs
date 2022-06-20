using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Programming_Courses_Site.Models;
using System.Diagnostics;
using Course.Shared;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace Programming_Courses_Site.Controllers
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

        public IActionResult GetCourse(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            ProgrammingCourse? model = db.ProgrammingCourses.SingleOrDefault(c => c.CourseId == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);


        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}