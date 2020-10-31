using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Data.Interfaces;
using TestPlatform.Models;

namespace TestPlatform.Contollers
{
    public class HomeController : Controller
    {
        private IEnumerable<Category> Categories { get; set; }
        public HomeController(IAllCategories categories)
        {
            Categories = categories.AllCategories;
        }
        public IActionResult Index()
        {
            return View(Categories);
        }
    }
}
