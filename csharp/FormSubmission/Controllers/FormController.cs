using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FormSubmission;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class FormController : Controller
    {
        // [HttpGet]
        // [Route("")]
        // public IActionResult Index()
        // {
        //     return View();
        // }

        [HttpGet]
        [Route("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
