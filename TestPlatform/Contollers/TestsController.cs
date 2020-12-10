using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TestPlatform.WEB.ViewModels;
using TestPlatform.BL;

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
                return RedirectToAction("Index", "Tests");
            }
            else
            {
                ModelState.AddModelError("!!!!!", "Все поля должны быть заполнены!");
            }
            return RedirectToAction("Create","Tests");
            
        }
        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if(!id.HasValue)
            {
                return NotFound();
            }
            var test = _TestService.GetTest(id.Value);
            if(test !=null)
            {
                return View(test);
            }
            return NotFound();
        }

       
        [HttpPost]
        public IActionResult Solve(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var test = _TestService.GetTest(id.Value);
            if (test != null)
            {
                var questions = test.Questions;
                var viewModel = new TestViewModel() { Id=test.Id, Name=test.Name, Description=test.Description, Categories=test.Categories,
                                                        Questions=questions, Time=test.Time};
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            var test = id.HasValue ? _TestService.GetTest(id.Value) : null;
            if (test == null)
            {
                return NotFound();
            }
            var viewModel = new TestViewModel() { Id=id.Value, Name = test.Name, Time = test.Time, Categories = test.Categories, Description = test.Description, Questions=test.Questions };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(TestViewModel viewModel)
        {
            var test = _TestService.GetTest(viewModel.Id);
            if(test != null)
            {
                test.Name = viewModel.Name;
                test.Time = viewModel.Time;
                test.Description = viewModel.Description;
                _TestService.UpdateTest(test);
                return RedirectToAction("Index", "Tests");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var test = id.HasValue ? _TestService.GetTest(id.Value) : null;
            if (test != null)
            {
                _TestService.DeleteTest(id.Value);
                return RedirectToAction("Index", "Tests");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Check(TestViewModel viewModel, int? id)
        {
            if (id.HasValue)
            {
                var usersAnswers = viewModel.UsersAnswers;
                var test = _TestService.GetTest(id.Value);
                int result = ValidateTestsResults.Check(usersAnswers, test);
                return Content(result.ToString());
            }
            else
            {
                return NotFound();
            }
        } 
    }
}
