using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Models;

namespace TestPlatform.Data.Interfaces
{
    interface IAllTests
    {
        IEnumerable<Test> Tests { get; }
        Test GetTestById(int testId);
    }
}
