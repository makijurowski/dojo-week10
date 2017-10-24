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
        // Dojodachi index
        [HttpGet]
        [Route("dojodachi")]
        public IActionResult Dojodachi()
        {
            // Get Dojodachi information from session and initialize default values
            DojodachiPet myDachi = HttpContext.Session.GetObjectFromJson<DojodachiPet>("myDachi");
            ViewBag.Image = "/images/pusheen_normal.gif";
            ViewBag.Status = "active";
            // If no myDachi instance exists, create one and start the game
            if (myDachi == null)
            {
                myDachi = new DojodachiPet();
                HttpContext.Session.SetObjectAsJson("myDachi", new DojodachiPet());
                ViewBag.Reaction = "";
                ViewBag.Message = "Welcome to Dojodachi! What should kitty do?";
            }
            // Save myDachi to ViewBag session
            ViewBag.Dojodachi = myDachi;
            return View();
        }

        // Player pressed interaction button
        [HttpPost]
        [Route("dojodachi/action")]
        public IActionResult Action(string action)
        {
            // Fetch Dojodachi information from session
            DojodachiPet myDachi = HttpContext.Session.GetObjectFromJson<DojodachiPet>("myDachi");
            // Default values
            Random GameRandom = new Random();
            ViewBag.Status = "active";
            // Logic for button interactions
            switch(action)
            {
                case "Feed":
                    if (myDachi.Meals > 0)
                    {
                        myDachi.Meals--;
                        int RandomChance = GameRandom.Next(1, 5);
                        if (RandomChance == 1)
                        {
                            ViewBag.Reaction = "Blegh! Dojodachi hates this food.";
                        }
                        else
                        {
                            myDachi.Fullness += GameRandom.Next(5, 11);
                            ViewBag.Reaction = "Dojodachi likes to eat!";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = "";
                        ViewBag.Message = "You have no food left to feed Dojodachi! Put him to work!";
                    }
                    break;
                case "Play":
                    if (myDachi.Energy > 0)
                    {
                        myDachi.Energy -= 5;
                        myDachi.Happiness += GameRandom.Next(5, 11);
                        ViewBag.Reaction = "Dojodachi is happy to play with you!";
                    }
                    else
                    {
                        ViewBag.Reaction = "";
                        ViewBag.Message = "Dojodachi has no energy to play! He needs to go to sleep first.";
                    }
                    break;
                case "Work":
                    if (myDachi.Energy > 0)
                    {
                        myDachi.Energy -= 5;
                        ViewBag.Reaction = "Dojodachi hates working but loves to earn meals!";
                        myDachi.Meals += GameRandom.Next(1, 4);
                    }
                    else
                    {
                        ViewBag.Reaction = "";
                        ViewBag.Message = "Dojodachi has no energy to work! He needs to go to sleep first.";
                    }
                    break;
                case "Sleep":
                    myDachi.Energy += 15;
                    myDachi.Fullness -= 5;
                    myDachi.Happiness -= 5;
                    ViewBag.Reaction = "Dojodachi feels well-rested!";
                    break;
                default:
                    ViewBag.Message = "Dojodachi says you don't know what you're doing!";
                    break;
            }
            // Player won the game
            if (myDachi.Energy >= 100 && myDachi.Fullness >= 100 && myDachi.Happiness >= 100)
            {
                ViewBag.Status = "gameover";
                ViewBag.Reaction = "";
                ViewBag.Message = "You won the game!";
            }
            // Player lost the game
            else if (myDachi.Fullness <= 0 || myDachi.Happiness <= 0)
            {
                ViewBag.Status = "gameover";
                ViewBag.Reaction = "";
                ViewBag.Message = "You lost the game!";
            }
            // Save myDachi information to session
            HttpContext.Session.SetObjectAsJson("myDachi", myDachi);
            ViewBag.Dojodachi = myDachi;
            ViewBag.Image = "/images/pusheen_normal.gif";
            return View("Dojodachi");
        }

        // Player pressed "Play Again?" button
        [HttpPost]
        [Route("dojodachi/reset")]
        public IActionResult Reset()
        {
            // Reset the game by clearing session, then redirect to Dojodachi
            HttpContext.Session.Clear();
            return RedirectToAction("Dojodachi");
        }
    }

    // Provided code to use Json data for session
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
