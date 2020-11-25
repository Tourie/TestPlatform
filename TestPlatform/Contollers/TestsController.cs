using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TestPlatform.Contollers
{
    [Authorize]
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
