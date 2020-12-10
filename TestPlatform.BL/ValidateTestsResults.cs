using System;
using System.Collections.Generic;
using TestPlatform.Core;
using TestPlatform.Services.ModelServices;
using System.Linq;

namespace TestPlatform.BL
{
    public static class ValidateTestsResults
    {
        public static int Check(Dictionary<int,int> usersResults, Test test)
        {
            int result = 0;
            var questions = test.Questions;
            foreach(var question in questions)
            {
                if (usersResults.ContainsKey(question.Id))
                {
                    var rightAnswer = question.Answers.FirstOrDefault(answer => answer.isTruth);
                    result += rightAnswer.Id == usersResults[question.Id] ? 1 : 0;
                }
            }
            return result;
        }
    }
}
