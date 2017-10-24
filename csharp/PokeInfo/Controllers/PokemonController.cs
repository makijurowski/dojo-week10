using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pokeinfo.Controllers
{
    public class PokemonController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                    System.Console.WriteLine("PokeInfo: " + PokeInfo);
                }
            ).Wait();
            ViewBag.Pokemon = PokeInfo;
            ViewBag.Name = PokeInfo["name"];
            ViewBag.Height = PokeInfo["height"];
            ViewBag.Weight = PokeInfo["weight"];

            // Digging...
            string stringTypes = JsonConvert.SerializeObject(PokeInfo["types"]);
            var TypesJSON = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(stringTypes);
            Dictionary<string, object> Types = TypesJSON.ElementAt(0);
            
            // Digging deeper...
            string stringType = JsonConvert.SerializeObject(Types["type"]);
            var TypeJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringType);
            Dictionary<string, string> Type = TypeJSON;

            ViewBag.Type = Type["name"];

            return View("Index");
        }
    }
}
