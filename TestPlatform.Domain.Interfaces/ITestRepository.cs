using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Domain.Core;

namespace TestPlatform.Domain.Interfaces
{
    public interface ITestRepository: IRepository<Test>
    {
        IEnumerable<Test> AllTests();
        Test GetTestById(int testId);
    }
}
