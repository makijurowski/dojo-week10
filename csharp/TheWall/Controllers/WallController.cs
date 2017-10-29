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
            ViewBag.AllUsers = new List<Dictionary<string, dynamic>>(_dbConnector.Query("SELECT * FROM Users"));
            
            List<Dictionary<string, dynamic>> Messages = new List<Dictionary<string, dynamic>>(_dbConnector.Query("SELECT * FROM Messages"));
            List<Dictionary<string, dynamic>> Comments = new List<Dictionary<string, dynamic>>(_dbConnector.Query("SELECT * FROM Comments"));
            Dictionary<int, dynamic> Sorted_Comments = new Dictionary<int, dynamic>();

            foreach (dynamic comment in Comments)
            {
                int id = (int)comment["message_id"];
                if (Sorted_Comments.ContainsKey(id) == false)
                {
                    Sorted_Comments.Add(id, new List<dynamic> {comment});
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
        [Route("PostMessage")]
        public IActionResult PostMessage(Message post)
        {
            if(ModelState.IsValid)
            {
                ViewBag.UserName = HttpContext.Session.GetString("name");
                ViewBag.UserId = HttpContext.Session.GetInt32("id");
                int? userId = (int)HttpContext.Session.GetInt32("id");
                string query = $@"INSERT INTO Messages (user_id, message, created_at, updated_at)
                            VALUES('{ViewBag.UserId}', '{post.UserMessage}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
                _dbConnector.Execute(query);
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
                int? userId = (int)HttpContext.Session.GetInt32("id");
                string query = $@"INSERT INTO Comments (message_id, user_id, comment, created_at, updated_at)
                            VALUES('{post.MessageId}', '{ViewBag.UserId}', '{post.UserComment}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
                _dbConnector.Execute(query);
                return RedirectToAction("Index", "Wall");
            }
        return View("Index");
        }
    }
}