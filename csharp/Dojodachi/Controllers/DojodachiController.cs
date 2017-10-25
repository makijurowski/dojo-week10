using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        // Dojodachi index
        [HttpGet]
        [Route("dojodachi")]
        public IActionResult Dojodachi()
        {
            // Get Dojodachi information from session and initialize default values
            DojodachiPet myDachi = HttpContext.Session.GetObjectFromJson<DojodachiPet>("myDachi");
            ViewBag.Image = "/images/dojodachi_dancing.gif";
            ViewBag.Status = "active";
            ViewBag.Reaction = "";
            ViewBag.Message = "Welcome to Dojodachi! What should kitty do?";
            // If no myDachi instance exists, create one and start the game
            if (myDachi == null)
            {
                myDachi = new DojodachiPet();
                HttpContext.Session.SetObjectAsJson("myDachi", new DojodachiPet());
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
                            ViewBag.Image = "/images/dojodachi_angry.gif";
                        }
                        else
                        {
                            myDachi.Fullness += GameRandom.Next(5, 11);
                            ViewBag.Reaction = "Dojodachi loves cheetos!";
                            ViewBag.Image = "/images/dojodachi_eating.gif";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = "You have no food left to feed Dojodachi! Put that kitty to work!";
                        ViewBag.Image = "/images/dojodachi_angry2.gif";
                    }
                    break;
                case "Play":
                    if (myDachi.Energy > 0)
                    {
                        int RandomChance = GameRandom.Next(1, 5);
                        if (RandomChance == 1)
                        {
                            myDachi.Energy -= 5;
                            ViewBag.Reaction = "Dojodachi doesn't want to play with you right now.";
                            ViewBag.Image = "/images/dojodachi_noplay.gif";
                        }
                        else
                        {
                            myDachi.Energy -= 5;
                            myDachi.Happiness += GameRandom.Next(5, 11);
                            ViewBag.Reaction = "Dojodachi is happy to play with you!";
                            ViewBag.Image = "/images/dojodachi_playing.gif";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = "Dojodachi is feeling too lazy to play! Perhaps he needs more energy first.";
                        ViewBag.Image = "/images/dojodachi_lazy.gif";
                    }
                    break;
                case "Work":
                    if (myDachi.Energy > 0)
                    {
                        myDachi.Energy -= 5;
                        myDachi.Meals += GameRandom.Next(1, 4);
                        ViewBag.Reaction = "Dojodachi reluctantly goes to work to earn dat food monies...";
                        ViewBag.Image = "/images/dojodachi_working.gif";
                    }
                    else
                    {
                        ViewBag.Reaction = "Dojodachi tried to go to work, but had no energy and fell asleep instead.";
                        ViewBag.Image = "/images/dojodachi_tired.gif";
                    }
                    break;
                case "Sleep":
                    myDachi.Energy += 15;
                    myDachi.Fullness -= 5;
                    myDachi.Happiness -= 5;
                    ViewBag.Reaction = "Dojodachi takes a catnap...";
                    ViewBag.Image = "/images/dojodachi_sleeping.gif";
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
                ViewBag.Message = "You won the game! Dojodachi loves you forever!";
                ViewBag.Image = "/images/dojodachi_happy.gif";
            }
            // Player lost the game
            else if (myDachi.Fullness <= 0 || myDachi.Happiness <= 0)
            {
                ViewBag.Status = "gameover";
                ViewBag.Reaction = "";
                ViewBag.Message = "You lost the game! Dojodachi wants a new owner!";
                ViewBag.Image = "/images/dojodachi_angry2.gif";
            }
            // Save myDachi information to session
            HttpContext.Session.SetObjectAsJson("myDachi", myDachi);
            ViewBag.Dojodachi = myDachi;
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
