using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VBS_FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> list = new List<string>();
            list.Add("u mama");
            list.Add("u pzpz");
            list.Add("u qzdqzd");
            list.Add("u gggg");
            list.Add("u rikkie");
            return View(list);
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