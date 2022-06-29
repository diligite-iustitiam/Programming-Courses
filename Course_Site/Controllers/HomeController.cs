using Microsoft.AspNetCore.Mvc;
using Course_Site.Models;
using System.Diagnostics;
using Course.Shared;


using System.Linq;

namespace Course_Site.Controllers
{
     public  class HomeController : Controller
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
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult DashBoard()
        {
            return View();
        }
        
        

        

        
        public IActionResult Courses(int pg = 1)
        {

            List<ProgrammingCourse> courses = db.ProgrammingCourses.ToList();
            const int pageSize = 1;
            if (pg < 1)
                pg = 1;
            int recsCount = courses.Count;
            var pager = new Pager(recsCount, pg, pageSize);
            int recsSkip = (pg-1) * pageSize;
            var data = courses.Skip(recsSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;


            // return View(courses);
            return View(data);
        }
        
        [HttpGet]
        public IActionResult GetCourse(string? course)
        {
            course = course.ToUpper();
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