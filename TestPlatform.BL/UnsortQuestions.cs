using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestPlatform.Core;

namespace TestPlatform.BL
{
    public static class UnsortQuestions
    {
        public static IEnumerable<T> Unsort<T>(List<T> param)
        {
            var unsorted_param = new List<T>();
            while (param.Count() != 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, param.Count() - 1);
                unsorted_param.Add(param[index]);
                param.RemoveAt(index);
            }
            return unsorted_param;
        }

        public static void UnsortQuestionsMethod(List<Question> questions)
        {
            var unsorted_q = Unsort(questions);
            foreach(var q in unsorted_q)
            {
                q.Answers = Unsort(q.Answers.ToList());
            }
        }
    }
}
