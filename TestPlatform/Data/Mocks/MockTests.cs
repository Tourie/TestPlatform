using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Data.Interfaces;
using TestPlatform.Models;

namespace TestPlatform.Data.Mocks
{
    public class MockTests : IAllTests
    {
        private readonly IAllCategories _allCategories = new MockCategory();
        public IEnumerable<Test> Tests
        {
            get
            {
                return new List<Test>
                {
                    new Test("Вопросы начального уровня", "Описание", 12){ Category = _allCategories.AllCategories.First() },
                    new Test("Вопросы среднего уровня", "Описание 2 теста", 16){ Category = _allCategories.AllCategories.First() },
                    new Test("Вопросы повышенного уровня", "Описание 3 теста", 20){ Category = _allCategories.AllCategories.Last() }
                };
            }
        }

        public Test GetTestById(int testId)
        {
            throw new NotImplementedException();
        }
    }
}
