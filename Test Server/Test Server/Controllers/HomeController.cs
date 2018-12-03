using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Test_Server.Models;
using SQRA_generator;


namespace Test_Server.Controllers
{
    public class HomeController : Controller
    {

        private static string textData;
        public IActionResult Index()
        {
            return View(ViewData);
        }

        [HttpPost]
        public IActionResult Generate(string text)
        {
            EngineSQRA webSQRA = new EngineSQRA(80, 50, text);
            webSQRA.GenerateQRA();
            
            return View();
        }



        public IActionResult Generate()
        {
            

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
