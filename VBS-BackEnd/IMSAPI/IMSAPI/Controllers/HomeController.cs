using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using InventoryManagementSystem.DishRepository;
using VBS_BackEnd.DishRepository;

namespace InventoryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["ImsConnectionstring"].ConnectionString;
        
        private readonly DishDelete _dishDelete;
        private readonly DishInsert _dishInsert;

       public HomeController(DishDelete dishDelete, DishInsert dishInsert) // Constructor injection
       {
            _dishDelete = dishDelete;
            _dishInsert = dishInsert;
       }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}