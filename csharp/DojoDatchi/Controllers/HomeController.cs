using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DojoDatchi.Controllers
{
    public class HomeController : Controller
    {
        // private static DojodachiInfo myDachi { get; set; }

        [HttpGet]
        [Route("dojodachi")]
        public IActionResult Dojodachi()
        {
            var myDachi = HttpContext.Session.GetObjectFromJson<DojodachiInfo>("myDachi");
            if (myDachi == null)
            {
                myDachi = new DojodachiInfo();
                HttpContext.Session.SetObjectAsJson("myDachi", new DojodachiInfo());
            }

            ViewBag.Dojodachi = myDachi;
            ViewBag.Status = "playing";
            ViewBag.Reaction = "";
            ViewBag.Message = "Welcome to Dojodachi! Ain't he a cutie?";

            return View();
        } 
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value= session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
