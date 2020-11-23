using System;
using System.Collections.Generic;
using TestPlatform.Core;

namespace TestPlatform.Services.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(Category item);
        void UpdateCategory(Category item);
        void DeleteCategory(int id);
        IEnumerable<Category> GetAll();
        Category GetCategory(int id);
        void Save();
    }
}
