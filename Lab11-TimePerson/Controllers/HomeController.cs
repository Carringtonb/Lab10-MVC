using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11_TimePerson.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_TimePerson.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Default Home Route for our home page
        /// </summary>
        /// <returns>Generated View</returns>

            [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startyear, int endYear)
        {
           
            return RedirectToAction("Results", new { startyear, endYear });

        }

        public IActionResult Results(int startYear, int endYear)
        {
            List<TimePerson> persons = TimePerson.GetPersons(startYear, endYear);
            return View(persons);
        }
    }
}