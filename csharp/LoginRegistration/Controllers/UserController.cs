using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LoginRegistration;
using LoginRegistration.Models;

namespace LoginRegistration.Controllers
{
    public class UserController : Controller
    {
        public UserController() { }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string FirstName, string LastName, string Email, int Age, string Password)
        {
            User NewUser = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Age = Age,
                Password = Password
            };

            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                return View();
            }

            else
            {
                return RedirectToAction("Success");
            }
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}