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
            if (TempData["movie_name"] != null)
            {
                System.Console.WriteLine(TempData["release_date"]);
                string query = string.Format("INSERT INTO movies (title, rating, release_date) VALUES('{0}', '{1}', '{2}');", TempData["movie_name"], TempData["rating"], TempData["release_date"]);
                _dbConnector.Execute(query);
            }
            List<Dictionary<string, object>> AllMovies = _dbConnector.Query("SELECT * FROM movies");
            return View();
        }

        [HttpPost]
        [Route("search")]
        public IActionResult QueryMovie(string search)
        {
            var MovieResult = new Dictionary<string, dynamic>();

            WebRequest.GetMovieDataAsync(search, ApiResponse =>
                {
                    MovieResult = ApiResponse;
                }
            ).Wait();

            TempData["movie_name"] = (string)MovieResult["movie_name"];
            TempData["rating"] = MovieResult["rating"];
            TempData["release_date"] = (string)MovieResult["release_date"];

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
