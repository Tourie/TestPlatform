using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Core;
using TestPlatform.Services.ModelServices;
using TestPlatform.Services.Interfaces;

namespace TestPlatform.Contollers
{
    public class categoriesController : Controller
    {
        private IEnumerable<Category> Categories { get; set; }
        public categoriesController(ICategoryService categoryService)
        {
            Categories = categoryService.GetAll();
        }
        public IActionResult Index()
        {
            return View(Categories);
        }
    }
}
