using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestPlatform.Core;

namespace TestPlatform.BL
{
    public static class UnsortQuestions
    {
        public static IEnumerable<Question> UnsortQuestionsMethod(List<Question> questions)
        {
            var unsorted_questions = new List<Question>();
            while (questions.Count() != 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, questions.Count() - 1);
                questions[index].Answers = UnsortAnswers(questions[index].Answers.ToList());
                unsorted_questions.Add(questions[index]);
                questions.RemoveAt(index);
            }
            return unsorted_questions;
        }

        private static IEnumerable<Answer> UnsortAnswers(List<Answer> answers)
        {
            var unsorted_answers = new List<Answer>();
            while (answers.Count() != 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, answers.Count() - 1);
                unsorted_answers.Add(answers[index]);
                answers.RemoveAt(index);
            }
            return unsorted_answers;
        }
    }
}
