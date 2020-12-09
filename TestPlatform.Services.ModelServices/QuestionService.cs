using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestPlatform.Core;
using TestPlatform.Infrastructure.Data;
using TestPlatform.Services.Interfaces;

namespace TestPlatform.Services.ModelServices
{
    public class QuestionService : IQuestionService
    {
        private IRepository<Question> _repository { get; set; }
        public QuestionService(IRepository<Question> repository)
        {
            _repository = repository;
        }
        public void DeleteQuestion(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _repository.GetAll();
        }

        public Question GetQuestion(int id)
        {
            return _repository.GetContext().Questions.Include(question => question.Answers).FirstOrDefault(q => q.Id == id);
        }

        public void UpdateQuestion(Question item)
        {
            _repository.Update(item);
        }

        public void CreateQuestion(Question question)
        {
            _repository.Create(question);
        }

        public Answer GetAnswer(int id, int question_id)
        {
            var question = GetQuestion(question_id);
            foreach(var answer in question.Answers)
            {
                if(answer.Id == id)
                {
                    return answer;
                }
            }
            return null;
        }
    }
}
