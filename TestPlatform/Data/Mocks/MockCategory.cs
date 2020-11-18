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
                    new Category("Матемактика","Вопросы по математике"){ Id = 1 },
                    new Category("Физика","Вопросы по физике"){ Id = 2 },
                    new Category("Программирование","Вопросы по программированию"){ Id = 3 }
                };
            }
        }
    }
}
