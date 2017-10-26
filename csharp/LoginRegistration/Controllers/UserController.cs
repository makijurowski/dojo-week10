using LoginRegistration;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
        [Route("submit")]
        public IActionResult Register(RegisterUser user)
        {
            if(ModelState.IsValid)
            {
                RegisterUser(user);
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser user)
        {
            List<Dictionary<string, object>> Users = DbConnector.Query($"SELECT id, password FROM Users WHERE email = '{user.LogEmail}'");
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

            // If user exists...
            if((Users.Count == 0 || user.LogPassword == null) || hasher.VerifyHashedPassword(user, (string)Users[0]["password"], user.LogPassword) == 0)
            {
                // But wrong information!
                ModelState.AddModelError("LogEmail", "Invalid email or password entered.");
            }
            if(ModelState.IsValid)
            {
                // Login user to session
                HttpContext.Session.SetInt32("id", (int)Users[0]["id"]);
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("success")]
        public string Success()
        {
            return "Success!";
        }
        public void RegisterUser(RegisterUser user)
        {
            PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
            string hashed = hasher.HashPassword(user, user.Password);

            string query = $@"INSERT INTO Users (first_name, last_name, email, password, created_at, updated_at)
                            VALUES('{user.FirstName}', '{user.LastName}', '{user.Email}', '{hashed}', Now(), Now());
                            SELECT LAST_INSERT_ID() as id";
            HttpContext.Session.SetInt32("id", Convert.ToInt32(DbConnector.Query(query)[0]["id"]));
        }
    }
}