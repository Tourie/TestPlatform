using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Data.Interfaces;
using TestPlatform.Models;

namespace TestPlatform.Contollers
{
    public class HomeController : Controller
    {
        private IEnumerable<Category> categories;
        private IEnumerable<Test> tests { get; set; }
        public HomeController(IAllCategories allCategories, IAllTests allTests)
        {
            tests = allTests.Tests;
            categories = allCategories.AllCategories;
        }

        public ViewResult Index()
        {
            return View(tests);
        }
    }
}
