using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MovieAPI.Properties;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    public class MovieController : Controller
    {
        private readonly DbConnector _dbConnector;

        public MovieController(DbConnector connect) 
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            return View();
        }

        [HttpPost]
        [Route("search")]
        public IActionResult QueryMovie(string search)
        {
            var MovieInfo = new Dictionary<string, object>();
            var MovieInfo2 = new Dictionary<string, dynamic>();

            WebRequest.GetMovieDataAsync(search, ApiResponse =>
                {
                    MovieInfo = ApiResponse;
                    MovieInfo2 = ApiResponse;
                }
            ).Wait();

            ViewBag.Movie = MovieInfo2["title"];
            ViewBag.Rating = MovieInfo2["rating"];
            // ViewBag.Movie = MovieInfo;

            ViewData["Message"] = "Your application description page.";

            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
