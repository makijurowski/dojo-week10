using LoginRegistration.Factory;
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
        private readonly RegisterUserFactory userFactory;
        private readonly DbConnector _dbConnector;
        public static int? UserId { get; set; }

        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
            userFactory = new RegisterUserFactory();
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("name");
            ViewBag.UserId = HttpContext.Session.GetInt32("id");
            ViewBag.AllUsers = new List<Dictionary<string, dynamic>>(_dbConnector.Query("SELECT * FROM Users"));

            List<Dictionary<string, dynamic>> Messages = new List<Dictionary<string, dynamic>>(_dbConnector.Query("SELECT * FROM Messages"));
            List<Dictionary<string, dynamic>> Comments = new List<Dictionary<string, dynamic>>(_dbConnector.Query("SELECT * FROM Comments"));
            Dictionary<int, dynamic> Sorted_Comments = new Dictionary<int, dynamic>();

            foreach (dynamic comment in Comments)
            {
                int id = (int)comment["message_id"];
                if (Sorted_Comments.ContainsKey(id) == false)
                {
                    Sorted_Comments.Add(id, new List<dynamic> { comment });
                    Messages[id - 1].Add("Sorted_Comments", Sorted_Comments[id]);
                }
                else
                {
                    Sorted_Comments[id].Add(comment);
                    Messages[id - 1]["Sorted_Comments"] = Sorted_Comments[id];
                }
            }

            ViewBag.Messages = Messages;
            ViewBag.SortedComments = Sorted_Comments;
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterUser user)
        {
            if(ModelState.IsValid)
            {
                userFactory.Add(user);
                ViewBag.RegisteredUsers = userFactory.FindAll();
                ViewBag.User = userFactory.FindByEmail(user.Email);
                ViewBag.UserId = ViewBag.User.Id;
                HttpContext.Session.SetString("name", (string)user.First_Name);
                HttpContext.Session.SetInt32("id", (int)ViewBag.UserId);
                return RedirectToAction("Index", "Wall");
            }
            return Redirect(Url.Action("Index", "Wall") + "#test2");
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            ViewBag.RegisteredUsers = userFactory.FindAll();
            return RedirectToAction("Index", "Wall");
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
            return RedirectToAction("Index", "Wall");
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