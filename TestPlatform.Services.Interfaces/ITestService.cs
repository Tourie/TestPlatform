using System;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;

namespace TestPlatform.Services.Interfaces
{
    public interface ITestService
    {
        void CreateTest(Test item);
        void UpdateTest(Test item);
        void DeleteTest(int id);
        IEnumerable<Test> GetAll();
        IEnumerable<Test> GetTestsByCategory(Category category);
        Test GetTest(int id);
        void Save();
    }
}
