using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using VBS_FrontEnd.Models;

namespace VBS_FrontEnd.Controllers
{
    public class VBSController : Controller
    {
        public ActionResult Home()
        {
            List<Dish> dishes = new List<Dish>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44313");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Dishes").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            dishes = JsonConvert.DeserializeObject<List<Dish>>(data);

            return View(dishes);
        }

        public ActionResult AddFood()
        {

            return View();
        }

        public ActionResult InventoryManagement()
        {
            ViewBag.Message = "General Management page page.";

            return View();
        }
        public ActionResult Recipe()
        {
            ViewBag.Message = "Specific recipe.";

            return View();
        }
        public ActionResult Recipes()
        {
            ViewBag.Message = "Alle recipes.";

            return View();
        }
        public ActionResult Stock()
        {
            ViewBag.Message = "Stock overview.";

            return View();
        }
    }
}