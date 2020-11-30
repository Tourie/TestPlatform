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
            var testCreateViewModel = new TestViewModel() { Categories = _CategoryService.GetAll() };
            return View(testCreateViewModel);
        }

        [HttpPost]
        public IActionResult Create(TestViewModel viewModel)
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
                return RedirectToAction("Update", "Tests", new { Test = test });
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

        [HttpGet]
        public IActionResult Solve(int? id)
        {
            if (id.HasValue)
            {
                return RedirectToAction("Detail", "Tests", new { id = id });
            }
            else
            {
                return RedirectToAction("Index", "Tests");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Solve(int id)
        {
            var test = _TestService.GetTest(id);
            return $"Test {test.Name} is running";
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var test = _TestService.GetTest(id);
            var viewModel = new TestViewModel() { Id=id, Name = test.Name, Time = test.Time, Categories = test.Categories, Description = test.Description, Questions=test.Questions };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddQuestion(int id)
        {
            var test = _TestService.GetTest(id);
            if (test != null)
            {
                var answers = new List<Answer>() { new Answer() { Name = "Ответ 1" }, new Answer() { Name = "Ответ 2" }, new Answer() { Name = "Ответ 3" } };
                var viewModel = new QuestionViewModel() { Answers = answers, TestId=id };
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddQuestion(QuestionViewModel viewModel, int id)
        {
            
            var question = new Question() { Name = viewModel.Name, Answers = viewModel.Answers };
            _TestService.AddQuestion(question, id);
            return RedirectToAction("Update", "Tests", new { id = id });
        }
    }
}
