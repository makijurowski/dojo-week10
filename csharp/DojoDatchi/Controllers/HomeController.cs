using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoDatchi.Models;

namespace DojoDatchi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("dojodachi")]
        public IActionResult Dojodachi(int Fullness=20, int Happiness=20, int Meals=3, int Energy=50)
        {
            
            return View();
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
