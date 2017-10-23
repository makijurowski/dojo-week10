using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace RapperAPI.Controllers {
    public class GroupController : Controller 
    {
        public List<Group> allGroups {get; set;}

        public GroupController() 
        {
            allGroups = JsonToFile<Group>.ReadJson();
        }

    }
}