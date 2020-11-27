using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Core;
using TestPlatform.Services.ModelServices;
using TestPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TestPlatform.WEB.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TestPlatform.Contollers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        /*private IEnumerable<Category> Categories { get; set; }*/
        private ICategoryService CategoryService { get; set; }
        private ITestService TestService { get; set; }
        public CategoriesController(ICategoryService categoryService, ITestService testService)
        {
            CategoryService = categoryService;
            TestService = testService;
        }
        public IActionResult Index()
        {
            var categories = CategoryService.GetAll();
            return View(categories);
        }
        public IActionResult Detail(int id)
        {
            var category = CategoryService.GetCategory(id);
            var tests = TestService.GetTestsByCategory(category);
            var viewModel = new CategoryTestsViewModel() { Category = category, Tests = tests };
            return View(viewModel);
        }
    }
}
