using System;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;

namespace TestPlatform.Services.Interfaces
{
    public interface IQuestionService
    {
        void CreateQuestion(Question item);
        void UpdateQuestion(Question item);
        void DeleteQuestion(int id);
        IEnumerable<Question> GetAll();
        Question GetQuestion(int id);
    }
}
