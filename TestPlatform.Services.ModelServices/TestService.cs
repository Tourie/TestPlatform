using System;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;
using TestPlatform.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestPlatform.Services.ModelServices
{
    public class TestService : ITestService
    {
        private IRepository<Test> _repository;
        public TestService(IRepository<Test> repository)
        {
            _repository = repository;
        }
        public void CreateTest(Test item)
        {
            _repository.Create(item);
        }

        public void DeleteTest(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Test> GetAll()
        {
            return _repository.GetAll();
        }

        public Test GetTest(int id)
        {
            var test = _repository.GetContext().Tests.Include(test => test.Categories)
                                            .Include(test => test.Questions)
                                            .FirstOrDefault(test => test.Id == id);
            var questions = new List<Question>();
            foreach(var q in test.Questions)
            {
                var quest = _repository.GetContext().Questions.Include(p => p.Answers).First(question=>question.Id==q.Id);
                questions.Add(quest);
            }
            test.Questions = questions;
            return test;
        }
        public void Save()
        {
            _repository.Save();
        }

        public void UpdateTest(Test item)
        {
            _repository.Update(item);
        }

        public IEnumerable<Test> GetTestsByCategory(Category category)
        {
            return _repository.GetContext().Categories.Include(categ => categ.Tests).FirstOrDefault(c=>c.Id == category.Id).Tests;
        }
        
        public void AddQuestion(Question question,int id)
        {
            var test = _repository.GetItem(id);
            if (test != null)
            {
                List<Question> questions = _repository.GetContext().Tests.Include(test => test.Questions).FirstOrDefault(test => test.Id == id).Questions.ToList()
                    ?? new List<Question>();
                questions.Add(question);
                test.Questions = questions;
                this.UpdateTest(test);
            }
        }
    }
}
