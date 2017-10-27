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
            ViewBag.Messages = AllMessages();
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

        public dynamic AllMessages()
        {
            string query = "SELECT * FROM Messages";
            var results = new List<Dictionary<string, dynamic>>();
            results = _dbConnector.Query(query);
            // HttpContext.Session.SetObjectAsJson("results", results);
            return results;
        }

        public void CreatePost(dynamic post)
        {
            int userId = (int)HttpContext.Session.GetInt32("id");
            string query = $@"INSERT INTO Messages (user_id, message, created_at, updated_at)
                            VALUES('{userId}', '{post.UserMessage}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
            _dbConnector.Execute(query);
        }

        public void CreateComment(dynamic post)
        {
            int userId = (int)HttpContext.Session.GetInt32("id");
            int messageId = (int)HttpContext.Session.GetInt32("message_id");
            string query = $@"INSERT INTO Comments (message_id, user_id, message, created_at, updated_at)
                            VALUES('{messageId}', '{userId}', '{post.UserMessage}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
            _dbConnector.Execute(query);
        }
    }
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}