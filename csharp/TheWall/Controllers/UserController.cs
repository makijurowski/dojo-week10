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
using TheWall;
using TheWall.Controllers;

namespace LoginRegistration.Controllers
{
    public class UserController : Controller
    {
        private readonly DbConnector _dbConnector;
        public static int? UserId { get; set; }

        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterUser user)
        {
            if(ModelState.IsValid)
            {
                // Register new user
                PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                string hashed = hasher.HashPassword(user, user.Password);

                string query = $@"INSERT INTO Users (first_name, last_name, email, password, created_at, updated_at)
                            VALUES('{user.FirstName}', '{user.LastName}', '{user.Email}', '{hashed}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
                HttpContext.Session.SetInt32("id", Convert.ToInt32(_dbConnector.Query(query)[0]["id"]));
                // Confirm by getting userinfo
                string userQuery = string.Format($"SELECT * FROM Users WHERE email = '{user.Email}'");
                List<Dictionary<string, object>> User = _dbConnector.Query(userQuery);
                HttpContext.Session.SetString("name", (string)User[0]["first_name"]);
                HttpContext.Session.SetInt32("id", (int)User[0]["id"]);
                ViewBag.UserId = HttpContext.Session.GetInt32("id");
                ViewBag.UserName = HttpContext.Session.GetString("name");
                return RedirectToAction("Index", "Wall");
            }
            return View("Index");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginUser user)
        {
            string loginQuery = string.Format($"SELECT id, first_name, password FROM Users WHERE email = '{user.LogEmail}'");
            List<Dictionary<string, object>> User = _dbConnector.Query(loginQuery);
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

            if((User.Count == 0 || user.LogPassword == null) || hasher.VerifyHashedPassword(user, (string)User[0]["password"], user.LogPassword) == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid email or password entered.");
            }
            if(ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", (string)User[0]["first_name"]);
                HttpContext.Session.SetInt32("id", (int)User[0]["id"]);
                ViewBag.UserId = HttpContext.Session.GetInt32("id");
                ViewBag.UserName = HttpContext.Session.GetString("name");
                return RedirectToAction("Index", "Wall");
            }
            return View("Index");
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            ViewBag.UserId = null;
            ViewBag.UserName = null;
            return RedirectToAction("Index", "Wall");
        }
    }
}