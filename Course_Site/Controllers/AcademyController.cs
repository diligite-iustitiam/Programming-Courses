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
