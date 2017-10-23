using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RapperAPI.Models;
using JsonData;

namespace RapperAPI.Controllers
{
    public class HomeController : ArtistController
    {
        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("artists")]
        public JsonResult AllArtists()
        {
            return Json(allArtists);
        }

        [HttpGet]
        [Route("artists/name/{name}")]
        public JsonResult ArtistsByName(string name)
        {
            string artistName = name.ToLower();
            IEnumerable<Artist> currentArtist = allArtists.Where(artist => artist.ArtistName.ToLower() == artistName);
            return Json(currentArtist);
        }

        [HttpGet]
        [Route("artists/realname/{rname}")]
        public JsonResult ArtistsByRealName(string rname)
        {
            string realName = rname.ToLower();
            IEnumerable<Artist> currentArtist = allArtists.Where(artist => artist.RealName.ToLower().Contains(realName));
            return Json(currentArtist);
        }

        [HttpGet]
        [Route("artists/hometown/{town}")]
        public JsonResult ArtistsByHometown(string town)
        {
            string artistTown = town.ToLower();
            IEnumerable<Artist> currentArtist = allArtists.Where(artist => artist.Hometown.ToLower().Contains(town));
            return Json(currentArtist);
        }

        [HttpGet]
        [Route("artists/groupid/{id}")]
        public JsonResult ArtistsByGroupId(int id)
        {
            int groupId = id;
            IEnumerable<Artist> currentArtist = allArtists.Where(artist => artist.GroupId == groupId);
            return Json(currentArtist);
        }

        [HttpGet]
        [Route("groups")]
        public JsonResult AllGroups()
        {
            return Json(allGroups);
        }

        [HttpGet]
        [Route("groups/name/{name}")]
        public JsonResult GroupsByName(string name)
        {
            string groupName = name.ToLower();
            IEnumerable<Group> currentGroups = allGroups.Where(group => group.GroupName.ToLower().Contains(groupName));
            return Json(currentGroups);
        }

        [HttpGet]
        [Route("groups/id/{id}")]
        [Route("groups/id/{id}/{display}")]
        public JsonResult GroupById(int id, bool display)
        {
            int groupId = id;
            bool displayArtists = display; 
            var groups = allGroups.Where(group => group.Id == groupId);

            if(displayArtists)
            {
                groups = groups.GroupJoin(allArtists,
                group => group.Id,
                artists => artists.GroupId,
                (group, artists) => 
                {
                    group.Members = artists.ToList();
                    return group;
                });
            }
            return Json(groups);
        }
    }
}
