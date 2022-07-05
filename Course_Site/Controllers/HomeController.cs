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
     public  class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Programming_CoursesContext db;
        private readonly Academy academy;
        public HomeController(ILogger<HomeController> logger, Programming_CoursesContext db, Academy academy)
        {
            _logger = logger;
            this.db = db;
            this.academy = academy;
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
        public IActionResult AllCourses()
        {
            var courses = db.ProgrammingCourses.ToList();
            return View(courses);
        }
        [HttpGet]
        
        public IActionResult School()
        {
            return View(academy.StudentFaculties.ToList());
        }
        public async Task<IActionResult> GetCourse(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DurationSortParm"] = sortOrder == "Duration" ? "duration_desc" : "Duration";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price"; ;
            ViewData["CurrentFilter"] = searchString;
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var courses = from s in db.ProgrammingCourses
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.CourseName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    courses = courses.OrderBy(s =>  s.CourseName);
                    break;
                case "Duration":
                    courses = courses.OrderBy(s => s.Duration);
                    break;
                case "duration_desc":
                    courses = courses.OrderByDescending(s => s.Duration);
                    break;
                case "Price":
                    courses = courses.OrderBy(s =>(double) s.Price);
                    break;
                case "price_desc":
                    courses = courses.OrderByDescending(s => (double)s.Price);
                    break;
                default:
                    courses = courses.OrderBy(s => s.CourseId);
                    break;
            }
            int pageSize = 3;
            return View(courses);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}