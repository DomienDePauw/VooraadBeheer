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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7078");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/VBS/GetAllDishes").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            List<Dish> dishes = JsonConvert.DeserializeObject<List<Dish>>(data);

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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7078");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/VBS/GetAllDishes").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            List<Dish> dishes = JsonConvert.DeserializeObject<List<Dish>>(data);

            return View(dishes);
        }
        public ActionResult Stock()
        {
            ViewBag.Message = "Stock overview.";

            return View();
        }
    }
}