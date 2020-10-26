using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Models;

namespace TestPlatform.Data.Interfaces
{
    public interface IAllCategories
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
