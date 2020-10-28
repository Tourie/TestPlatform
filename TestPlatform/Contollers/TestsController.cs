using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Data.Interfaces;
using TestPlatform.Models;

namespace TestPlatform.Contollers
{
    public class TestsController : Controller
    {
        private IEnumerable<Category> categories;
        private IEnumerable<Test> tests { get; set; }
        public TestsController(IAllCategories allCategories, IAllTests allTests)
        {
            tests = allTests.Tests;
            categories = allCategories.AllCategories;
        }

        public IActionResult Index()
        {
            return View(tests);
        }
    }
}
