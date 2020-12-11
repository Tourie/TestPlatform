using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;
using TestPlatform.WEB.ViewModels;

namespace TestPlatform.WEB.Contollers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private  ITestService _TestService { get; set; }
        private  IQuestionService _QuestionService { get; set; }
        private UserManager<User> _UserManager { get; set; }
        public QuestionsController(IQuestionService questionService, ITestService testService, UserManager<User> userManager)
        {
            _TestService = testService;
            _QuestionService = questionService;
            _UserManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? testId)
        {
            if (!testId.HasValue)
            {
                return NotFound();
            }
            else
            {
                var user = await _UserManager.GetUserAsync(User);
                var test = _TestService.GetTest(testId.Value);
                if (test != null && test.OwnerId == user.Id)
                {
                    var answers = new Answer[] { new Answer() { Name = "Ответ 1" }, new Answer() { Name = "Ответ 2" }, new Answer() { Name = "Ответ 3" } };
                    var viewModel = new QuestionViewModel() { Answers = answers, TestId = testId.Value };
                    return View(viewModel);
                }
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(QuestionViewModel viewModel, int testId)
        {
            var test = _TestService.GetTest(testId);
            var user = await _UserManager.GetUserAsync(User);
            if (ModelState.IsValid && test != null && test.OwnerId == user.Id)
            {
                var question = new Question() { Name = viewModel.Name, Answers = viewModel.Answers, Test = test };
                foreach (var q in question.Answers)
                {
                    if (q.Name == viewModel.NameRightAnswer) q.isTruth = true;
                    else q.isTruth = false;
                }
                _QuestionService.CreateQuestion(question);
                return RedirectToAction("Update", "Tests", new { id = testId });
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Все поля должны быть заполнены");
            }
            viewModel.TestId = testId;
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
          
            var question = id.HasValue ? _QuestionService.GetQuestion(id.Value) : null;
            var user = await _UserManager.GetUserAsync(User);
            if (question != null && question.Test.OwnerId == user.Id)
            {
                var rightAnswer = _QuestionService.GetRightAnswer(question.Id);
                var viewModel = new QuestionViewModel() { Answers = question.Answers, TestId = question.Testid, 
                    Id=question.Id, Name=question.Name, RightAnswer=rightAnswer };
                return View(viewModel);
            }
            return NotFound();
           
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuestionViewModel viewModel, int? id)
        {
            var question = id.HasValue ? _QuestionService.GetQuestion(id.Value) : null;
            var user = await _UserManager.GetUserAsync(User);
            if (ModelState.IsValid && question != null && user.Id == question.Test.OwnerId)
            {
                question.Name = viewModel.Name;
                question.Answers = viewModel.Answers;
                foreach(var q in question.Answers)
                {
                    if (q.Name == viewModel.NameRightAnswer) q.isTruth = true;
                    else q.isTruth = false;
                }
                _QuestionService.UpdateQuestion(question);
                return RedirectToAction("Update", "Questions", new { id = id.Value });
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var question = id.HasValue ? _QuestionService.GetQuestion(id.Value) : null;
            var user = await _UserManager.GetUserAsync(User);
            if (question != null && question.Test.OwnerId == user.Id)
            {
                _QuestionService.DeleteQuestion(question.Id);
                return RedirectToAction("Update", "Tests", new { id = question.Testid });
            }
            return NotFound();
        }
    }
}
