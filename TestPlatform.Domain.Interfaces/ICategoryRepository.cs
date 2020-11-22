using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Domain.Core;

namespace TestPlatform.Domain.Interfaces
{
    public interface ICategoryRepository: IRepository<Category>
    {
        IEnumerable<Category> AllCategories();
        Category GetCategory(int id);
    }
}
