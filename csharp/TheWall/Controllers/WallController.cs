using LoginRegistration;
using LoginRegistration.Models;
using LoginRegistration.Controllers;
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
using TheWall.Models;

namespace TheWall.Controllers
{
    public class WallController : Controller
    {
        private readonly DbConnector _dbConnector;

        public WallController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            TempData["UserName"] = TempData["UserName"];
            TempData["UserId"] = TempData["UserId"];
            System.Console.WriteLine("\n\n\n\n");
            System.Console.WriteLine(TempData["UserName"]);
            System.Console.WriteLine(TempData["UserId"]);
            System.Console.WriteLine("\n\n\n\n");
            return View();
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post(Message post)
        {
            if(ModelState.IsValid)
            {
                CreatePost(post);
                TempData["UserId"] = TempData["UserId"];
                return RedirectToAction("Index", "Wall");
            }
        return View("Index");
        }

        public void CreatePost(dynamic post)
        {
            int userId = (int)HttpContext.Session.GetInt32("id");
            string query = $@"INSERT INTO Messages (user_id, message, created_at, updated_at)
                            VALUES('{userId}', '{post.UserMessage}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
            _dbConnector.Execute(query);
        }
    }
}