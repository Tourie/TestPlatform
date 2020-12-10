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
    public class QuestionsController : Controller
    {
        private ITestService _TestService { get; set; }
        private IQuestionService _QuestionService { get; set; }
        public QuestionsController(IQuestionService questionService, ITestService testService)
        {
            _TestService = testService;
            _QuestionService = questionService;
        }
        [HttpGet]
        public IActionResult Create(int? testId)
        {
            if (!testId.HasValue)
            {
                return NotFound();
            }
            else
            {
                var test = _TestService.GetTest(testId.Value);
                if (test != null)
                {
                    var answers = new Answer[] { new Answer() { Name = "Ответ 1" }, new Answer() { Name = "Ответ 2" }, new Answer() { Name = "Ответ 3" } };
                    var viewModel = new QuestionViewModel() { Answers = answers, TestId = testId.Value };
                    return View(viewModel);
                }
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create(QuestionViewModel viewModel, int testId)
        {
            var test = _TestService.GetTest(testId);
            if (ModelState.IsValid && test != null)
            {
                var question = new Question() { Name = viewModel.Name, Answers = viewModel.Answers, Test = test };
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
        public IActionResult Update(int? id)
        {
          
            var question = id.HasValue ? _QuestionService.GetQuestion(id.Value) : null;
            if (question != null)
            {
                var rightAnswer = _QuestionService.GetRightAnswer(question.Id);
                var viewModel = new QuestionViewModel() { Answers = question.Answers, TestId = question.Testid, 
                    Id=question.Id, Name=question.Name, RightAnswer=rightAnswer };
                return View(viewModel);
            }
            return NotFound();
           
        }

        [HttpPost]
        public IActionResult Update(QuestionViewModel viewModel, int? id)
        {
            var question = id.HasValue ? _QuestionService.GetQuestion(id.Value) : null;
            if (ModelState.IsValid && question != null)
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
        public IActionResult Delete(int? id)
        {
            var question = id.HasValue ? _QuestionService.GetQuestion(id.Value) : null;
            if (question != null)
            {
                _QuestionService.DeleteQuestion(question.Id);
                return RedirectToAction("Update", "Tests", new { id = question.Testid });
            }
            return NotFound();
        }
    }
}
