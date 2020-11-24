using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Data.Interfaces;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;

namespace TestPlatform.Contollers
{
    public class TestsController : Controller
    {
        private IEnumerable<Test> tests { get; set; }
        public TestsController(ITestService testService)
        {
            tests = testService.GetAll();
        }

        public IActionResult Index()
        {
            return View(tests);
        }
    }
}
