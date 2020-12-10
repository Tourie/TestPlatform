using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestPlatform.WEB.Contollers
{
    public class MyResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
