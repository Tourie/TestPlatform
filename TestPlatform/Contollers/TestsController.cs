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
using Microsoft.AspNetCore.Identity;

namespace TestPlatform.Contollers
{
    [Authorize]
    public class TestsController : Controller
    {
        private ITestService _TestService { get; set; }
        private ICategoryService _CategoryService { get; set; }
        private ITestResultService _TestResultService { get; set; }
        private ICommentService _CommentService { get; set; }
        private UserManager<User> _userManager { get; set; }
        public TestsController(ITestService testService, ICategoryService categoryService, UserManager<User> userManager, ITestResultService testResultService, ICommentService commentService)
        {
            _TestService = testService;
            _CategoryService = categoryService;
            _TestResultService = testResultService;
            _CommentService = commentService;
            _userManager = userManager;
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
        public async Task<IActionResult> Create(TestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var AllCategories = _CategoryService.GetAll();
                var testCategories = new List<Category>();
                foreach(var category in viewModel.TestCategory)
                {
                    testCategories.Add(AllCategories.First(item => item.Id == category));
                }
                Test test = new Test() 
                { 
                    Name = viewModel.Name, 
                    Description = viewModel.Description, 
                    Time = viewModel.Time, 
                    Categories = testCategories, 
                    OwnerId=_userManager.GetUserId(User), 
                    Owner = await _userManager.GetUserAsync(User) 
                };
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
                var comments = _CommentService.GetCommentsByTest(test).ToList();

                foreach (var item in comments)
                {
                    /*if (item.UserId == null)
                    {
                        comments.Remove(item);
                    }*/

                    item.User = _userManager.FindByIdAsync(item.UserId).Result;
                }

                ViewBag.Comments = _CommentService.GetCommentsByTest(test);

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
                var questions = test.Questions.ToList();
                var unsorted_questions = UnsortQuestions.UnsortQuestionsMethod(questions);
                var viewModel = new TestViewModel()
                {
                    Id = test.Id,
                    Name = test.Name,
                    Description = test.Description,
                    Categories = test.Categories,
                    Questions = unsorted_questions,
                    Time = test.Time
                };
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var test = id.HasValue ? _TestService.GetTest(id.Value) : null;
            if (test == null || user.Id.ToString() != test.OwnerId)
            {
                return NotFound();
            }
            var viewModel = new TestViewModel() { Id=id.Value, Name = test.Name, Time = test.Time, Categories = test.Categories, Description = test.Description, Questions=test.Questions };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TestViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var test = _TestService.GetTest(viewModel.Id);
            if(test != null && user.Id == test.OwnerId)
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
        public async Task<IActionResult> Delete(int? id)
        {
            var test = id.HasValue ? _TestService.GetTest(id.Value) : null;
            var user = await _userManager.GetUserAsync(User);
            if (test != null && user.Id == test.OwnerId)
            {
                _TestService.DeleteTest(id.Value);
                return RedirectToAction("Index", "Tests");
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Result(TestViewModel viewModel, int? id)
        {
            if (id.HasValue)
            {
                DateTime finished = DateTime.Now;
                var usersAnswers = viewModel.UsersAnswers;
                var test = _TestService.GetTest(id.Value);
                // check answers
                int rightAnswers = ValidateTestsResults.Check(usersAnswers, test);
                // get user
                var user = await _userManager.GetUserAsync(HttpContext.User);
                // create testResult in database
                var testResult = new TestResult() 
                { 
                    RightAnswers = rightAnswers, finished = finished, 
                    Test = test, TestId = test.Id, 
                    Answers = test.Questions.Count(),
                    User = user, 
                    UserId = user.Id
                };
                _TestResultService.Create(testResult);
                // create viewModel
                var resultViewModel = new TestResultViewModel() 
                { 
                    RightAnswers = rightAnswers, 
                    finished = finished, 
                    Test = test, 
                    User = user, 
                    Answers = test.Questions.Count() 
                };
                return View(resultViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        
    }
}
