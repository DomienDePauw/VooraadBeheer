using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using VBS_FrontEnd.Models;

namespace VBS_FrontEnd.Controllers {

    public class VBSController : Controller {

        public ActionResult Home() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7078");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/VBS/GetAllDishes").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            List<Dish> dishes = JsonConvert.DeserializeObject<List<Dish>>(data);

            return View(dishes);
        }

        public ActionResult AddFood() {
            return View();
        }

        public ActionResult InventoryManagement() {
            ViewBag.Message = "General Management page page.";

            return View();
        }

        public ActionResult Recipe(int Id) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7078");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"/api/VBS/GetAllDishesByGroupId{Id}").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            List<DishWithNames> dishes = JsonConvert.DeserializeObject<List<DishWithNames>>(data);
            List<DishWithNames> primary = new List<DishWithNames>();
            primary.Add(dishes.FirstOrDefault(dish => dish.Id == Id));
            for (int i = 0; i < dishes.Count; i++) {
                if (dishes[i].Id != Id) {
                    primary.Add(dishes[i]);
                }
            }
            return View(primary);
        }

        public ActionResult Recipes(int? subId) {
            if (subId == null)
            {
                subId = 0;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7078");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"/api/VBS/GetAllDishes{subId}").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            List<Dish> dishes = JsonConvert.DeserializeObject<List<Dish>>(data);

            return View(dishes);
        }

        public ActionResult Stock() {
            ViewBag.Message = "Stock overview.";

            return View();
        }
    }
}