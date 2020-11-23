using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Core;

namespace TestPlatform.Contollers
{
    public class categoriesController : Controller
    {
        private IEnumerable<Category> Categories { get; set; }
        public categoriesController(ICategoryRepository categoryRepository)
        {
            Categories = categoryRepository.AllCategories();
        }
        public IActionResult Index()
        {
            return View(Categories);
        }
    }
}
