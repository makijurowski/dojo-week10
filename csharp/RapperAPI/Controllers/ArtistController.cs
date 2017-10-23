using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace RapperAPI.Controllers {

    
    public class ArtistController : GroupController 
    {

        public List<Artist> allArtists;

        public ArtistController() 
        {
            allArtists = JsonToFile<Artist>.ReadJson();
        }
    }
}