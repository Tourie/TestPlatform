using System;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;

namespace TestPlatform.Services.Interfaces
{
    public interface ITestResultService
    {
        void Create(TestResult testResult);
        void Update(TestResult testResult);
        IEnumerable<TestResult> GetUserResults(string user_id);
        IEnumerable<TestResult> GetTestResults(Test test);
    }
}
