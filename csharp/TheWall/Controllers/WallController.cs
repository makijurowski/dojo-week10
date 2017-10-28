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
            ViewBag.UserName = HttpContext.Session.GetString("name");
            ViewBag.UserId = HttpContext.Session.GetInt32("id");
            ViewBag.Messages = AllMessages();
            ViewBag.Comments = AllComments();
            ViewBag.AllData = new List<Dictionary<string, dynamic>>(_dbConnector.Query("SELECT * FROM Comments"));
            return View();
        }

        [HttpPost]
        [Route("PostMessage")]
        public IActionResult PostMessage(Message post)
        {
            if(ModelState.IsValid)
            {
                ViewBag.UserName = HttpContext.Session.GetString("name");
                ViewBag.UserId = HttpContext.Session.GetInt32("id");
                CreatePost(post);
                return RedirectToAction("Index", "Wall");
            }
        return View("Index");
        }

        [HttpPost]
        [Route("PostComment")]
        public IActionResult PostComment(Comment post)
        {
            if(ModelState.IsValid)
            {
                ViewBag.UserName = HttpContext.Session.GetString("name");
                ViewBag.UserId = HttpContext.Session.GetInt32("id");
                CreateComment(post);
                return RedirectToAction("Index", "Wall");
            }
        return View("Index");
        }

        public dynamic AllMessages()
        {
            string query = "SELECT * FROM Messages";
            var results = new List<Dictionary<string, dynamic>>();
            results = _dbConnector.Query(query);
            return results;
        }

        public dynamic AllComments()
        {
            string query = "SELECT * FROM Comments";
            var results = new List<Dictionary<string, dynamic>>();
            results = _dbConnector.Query(query);
            return results;
        }

        public void CreatePost(dynamic post)
        {
            int? userId = (int)HttpContext.Session.GetInt32("id");
            string query = $@"INSERT INTO Messages (user_id, message, created_at, updated_at)
                            VALUES('{userId}', '{post.UserMessage}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
            _dbConnector.Execute(query);
        }

        public void CreateComment(dynamic post)
        {
            int? userId = (int)HttpContext.Session.GetInt32("id");
            // int messageId = (int)TempData["message_id"];
            string query = $@"INSERT INTO Comments (message_id, user_id, comment, created_at, updated_at)
                            VALUES('{post.MessageId}', '{userId}', '{post.UserComment}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
            _dbConnector.Execute(query);
        }
    }
}