using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;

namespace TestPlatform.WEB.Contollers
{
    [Authorize]
    public class MyResultsController : Controller
    {
        private ITestResultService _testResultService { get; set; }
        private ITestService _testService { get; set; }
        private UserManager<User> _userManager { get; set; }
        public MyResultsController(ITestResultService testResultService, UserManager<User> userManager, ITestService testService)
        {
            _testResultService = testResultService;
            _userManager = userManager;
            _testService = testService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            var results = _testResultService.GetUserResults(userId).ToList();
            foreach(var result in results)
            {
                result.User = await _userManager.FindByIdAsync(result.Test.OwnerId);
                result.Test = _testService.GetTest(result.TestId);
            }
            results.Sort((result1, result2) =>
            {
                if (result1.finished < result2.finished) return 1;
                else if (result1.finished > result2.finished) return -1;
                else return 0;
            });
            return View(results);
        }
    }
}
