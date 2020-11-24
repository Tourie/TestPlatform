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
    public class CategoriesController : Controller
    {
        /*private IEnumerable<Category> Categories { get; set; }*/
        private ICategoryService CategoryService { get; set; }
        public CategoriesController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = CategoryService.GetAll();
            return View(categories);
        }
        public IActionResult Details(int id)
        {
            Category category = CategoryService.GetCategory(id);
            return View(category);
        }
    }
}
