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
            DojodachiInfo myDachi = HttpContext.Session.GetObjectFromJson<DojodachiInfo>("myDachi");
            ViewBag.Image = "/images/pusheen_normal.gif";
            ViewBag.Status = "active";
            if (myDachi == null)
            {
                myDachi = new DojodachiInfo();
                HttpContext.Session.SetObjectAsJson("myDachi", new DojodachiInfo());
                ViewBag.Reaction = "";
                ViewBag.Message = "Welcome to Dojodachi! What should kitty do?";
            }
            ViewBag.Dojodachi = myDachi;
            return View();
        }

        [HttpPost]
        [Route("dojodachi/action")]
        public IActionResult Action(string action)
        {
            DojodachiInfo myDachi = HttpContext.Session.GetObjectFromJson<DojodachiInfo>("myDachi");
            // Default values
            ViewBag.Status = "active";
            ViewBag.Message = "You performed an action!";

            switch(action)
            {
                case "Feed":
                    ViewBag.Reaction = "Dojodachi likes food!";
                    myDachi.Fullness += 10;
                    myDachi.Meals--;
                    break;

                case "Play":
                    ViewBag.Reaction = "Dojodachi likes playing!";
                    myDachi.Happiness += 20;
                    break;

                case "Work":
                    ViewBag.Reaction = "Dojodachi hates working!";
                    myDachi.Happiness -= 10;
                    break;

                case "Sleep":
                    ViewBag.Reaction = "Dojodachi likes sleeping!";
                    myDachi.Energy += 20;
                    break;

                default:
                    ViewBag.Reaction = "Dojodachi says you suck!";
                    break;
            }
            if (myDachi.Energy >= 100 || myDachi.Fullness >= 100 || myDachi.Happiness >= 100)
            {
                ViewBag.Status = "gameover";
                ViewBag.Reaction = "";
                ViewBag.Message = "You won the game!";
            }
            else if (myDachi.Fullness <= 0 || myDachi.Happiness <= 0)
            {
                ViewBag.Status = "gameover";
                ViewBag.Reaction = "";
                ViewBag.Message = "You lost the game!";
            }
            HttpContext.Session.SetObjectAsJson("myDachi", myDachi);
            ViewBag.Dojodachi = myDachi;
            ViewBag.Image = "/images/pusheen_normal.gif";
            return View("Dojodachi");
        }

        [HttpPost]
        [Route("dojodachi/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Dojodachi");
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
