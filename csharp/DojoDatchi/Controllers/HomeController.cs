using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DojoDatchi.Models;

namespace DojoDatchi.Controllers
{
    public class HomeController : Controller
    {
        public Dojodachi currentDachi = new Dojodachi();

        [HttpGet]
        [Route("index")]
        public IActionResult Dojodachi()
        {
            currentDachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");

            if (currentDachi == null)
            {
                HttpContext.Session.SetObjectAsJson("Dojodachi", new Dojodachi());
            }

            ViewBag.Dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            ViewBag.Status = "playing";
            ViewBag.Reaction = "";
            ViewBag.Message = "Welcome to Dojodachi! Ain't he a cutie?";

            return View();
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
            string value= session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
