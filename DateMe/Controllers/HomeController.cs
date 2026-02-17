using System.Diagnostics;
using System.Linq;
using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private DatingApplicationContext _context;
        public HomeController(DatingApplicationContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DatingApplication()
        {
            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

            return View("DatingApplication");
        }

        [HttpPost]
        public IActionResult DatingApplication(ApplicationViewModel response)
        {
            _context.Applications.Add(response); // Add the response to the database context
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult Waitlist()
        {
            // Linq
            var applications = _context.Applications
                .Include(x => x.Major)
                .Where(x => x.CreeperStalker == false)
                .OrderBy(x => x.LastName)
                .ToList();

            return View(applications);
        }

        public IActionResult Edit(int recordID)
        {
            var recordToEdit = _context.Applications
                .Where(x => x.ApplicationID == recordID);

            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

            return View("DatingApplication");
        }
    }
}
