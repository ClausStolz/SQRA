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
            //Dictionary<int, bool> testsDict = new Dictionary<int, bool>();
            //testsDict.Add(1, true);
            //testsDict.Add(2, false);
            HomeModel HomeModel = new HomeModel();

            //ViewBag.testsDict = testsDict;
            ViewData["tests"] = HomeModel.ReturnDict().Count;
            return View(ViewData);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public IActionResult Generate(string text)
        {
            //ViewBag.Text = text;
            textData = text;
            EngineSQRA webSQRA = new EngineSQRA(80, 50, textData);
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
