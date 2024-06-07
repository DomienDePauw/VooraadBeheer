using VBS.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBS_BackEnd.Models;

namespace VBS_BackEnd.Controllers {

    public class HomeController : Controller {
        public ActionResult Host() {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}