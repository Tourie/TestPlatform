using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Data.Interfaces;
using TestPlatform.Models;

namespace TestPlatform.Contollers
{
    public class TestController : Controller
    {
        private IEnumerable<Category> categories;
        private IEnumerable<Test> tests { get; set; }
        public TestController(IAllCategories allCategories, IAllTests allTests)
        {
            tests = allTests.Tests;
            categories = allCategories.AllCategories;
        }

        public ViewResult Index()
        {
            return View(tests as List<Test>);
        }
    }
}
