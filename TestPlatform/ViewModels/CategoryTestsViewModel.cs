using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;

namespace TestPlatform.WEB.ViewModels
{
    public class CategoryTestsViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Test> Tests { get; set; }
    }
}
