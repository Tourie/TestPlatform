using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TestPlatform.WEB.ViewModels;

namespace TestPlatform.Contollers
{
    [Authorize]
    public class TestsController : Controller
    {
        private ITestService _TestService { get; set; }
        private ICategoryService _CategoryService { get; set; }
        public TestsController(ITestService testService, ICategoryService categoryService)
        {
            _TestService = testService;
            _CategoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_TestService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var testCreateViewModel = new TestCreateViewModel() { Categories = _CategoryService.GetAll() };
            return View(testCreateViewModel);
        }

        [HttpPost]
        public IActionResult Create(TestCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var AllCategories = _CategoryService.GetAll();
                var testCategories = new List<Category>();
                foreach(var category in viewModel.TestCategory)
                {
                    testCategories.Add(AllCategories.First(item => item.Id == category));
                }
                Test test = new Test() { Name = viewModel.Name, Description = viewModel.Description, Time = viewModel.Time, Categories = testCategories };
                _TestService.CreateTest(test);
                return RedirectToAction("Index", "Tests");
            }
            else
            {
                ModelState.AddModelError("!!!!!", "Все поля должны быть заполнены!");
            }
            return RedirectToAction("Create","Tests");
            
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var test = _TestService.GetTest(id);
            return View(test);
        }
    }
}
