using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CallingCard.Models;

namespace CallingCard.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("{fname}/{lname}/{age}/{color}")]
        public JsonResult JsonProcessor(string fname, string lname, int age, string color)
        {
            var UserInfo = new {
                FirstName = fname,
                LastName = lname,
                Age = age,
                FavoriteColor = color,
            };
            return Json(UserInfo);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
