using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;
using TestPlatform.Infrastructure.Data;
using TestPlatform.Services.Interfaces;

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
            return _repository.GetContext().testResults.Where(result => result.Test.Id == test.Id);
        }

        public IEnumerable<TestResult> GetUserResults(string user_id)
        {
            return _repository.GetContext().testResults.Where(result => result.User.Id == user_id);
        }
    }
}
