using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Core;
using TestPlatform.Services.Interfaces;

namespace TestPlatform.Contollers
{
    public class HomeController : Controller
    {
        private IEnumerable<Category> Categories { get; set; }
        public HomeController(ICategoryService categoryService)
        {
            Categories = categoryService.GetAll();
        }
        public IActionResult Index()
        {
            /*throw new ArgumentException();*/
            return View(Categories);
        }
    }
}
