using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Http;
using VBS_BackEnd.Models;

namespace InventoryManagementSystemAPI.Controllers
{
    public class VBSController : ApiController
    {
        // GET api/values
        [Route("api/Dishes")]
        [AcceptVerbs("Get")]
        public List<Dish> GetDishes()
        {
            var dishes = 
            return dishes;
        }
    }
}
