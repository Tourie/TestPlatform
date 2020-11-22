using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Data.Interfaces;
using TestPlatform.Domain.Interfaces;
using TestPlatform.Domain.Core;

namespace TestPlatform.Contollers
{
    public class HomeController : Controller
    {
        private IEnumerable<Category> Categories { get; set; }
        public HomeController(ICategoryRepository categoryRepository)
        {
            Categories = categoryRepository.AllCategories();
        }
        public IActionResult Index()
        {
            return View(Categories);
        }
    }
}
