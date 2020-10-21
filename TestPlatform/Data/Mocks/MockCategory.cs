using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Data.Interfaces;
using TestPlatform.Models;

namespace TestPlatform.Data.Mocks
{
    public class MockCategory : IAllCategories
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category("Матемактика","Вопросы по математике"),
                    new Category("Физика","Вопросы по физике"),
                    new Category("Программирование","Вопросы по программированию")
                };
            }
        }
    }
}
