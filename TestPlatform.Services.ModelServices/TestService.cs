using System;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;
using TestPlatform.Infrastructure.Data;

namespace TestPlatform.Services.ModelServices
{
    public class TestService : ITestService
    {
        private IRepository<Test> _repository;
        public TestService(IRepository<Test> repository)
        {
            _repository = repository;
        }
        public void CreateTest(Test item)
        {
            _repository.Create(item);
        }

        public void DeleteTest(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Test> GetAll()
        {
            return _repository.GetAll();
        }

        public Test GetTest(int id)
        {
            return _repository.GetItem(id);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void UpdateTest(Test item)
        {
            _repository.Update(item);
        }
    }
}
