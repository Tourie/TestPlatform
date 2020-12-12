using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;
using TestPlatform.Infrastructure.Data;
using TestPlatform.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestPlatform.Services.ModelServices
{
    public class TestResultService : ITestResultService
    {
        private IRepository<TestResult> _repository;
        public TestResultService(IRepository<TestResult> repository)
        {
            this._repository = repository;
        }
        public void Create(TestResult testResult)
        {
            _repository.Create(testResult);
        }

        public IEnumerable<TestResult> GetTestResults(Test test)
        {
            return _repository.GetContext().testResults.Where(result => result.TestId == test.Id).ToList();
        }

        public IEnumerable<TestResult> GetUserResults(string user_id)
        {
            return _repository.GetContext().testResults.Where(result => result.UserId == user_id).Include(result=>result.Test);
        }

        public void Update(TestResult testResult)
        {
            _repository.Update(testResult);
        }
    }
}
