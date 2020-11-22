using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Domain.Interfaces;

namespace TestPlatform.Contollers
{
    public class categoriesController : Controller
    {
        public IActionResult Index(ICategoryRepository categoryRepository)
        {
            var categories = categoryRepository.AllCategories();
            return View(categories);
        }
    }
}
