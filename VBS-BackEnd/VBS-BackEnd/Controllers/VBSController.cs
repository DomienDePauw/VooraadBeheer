using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VBS_BackEnd.Controllers
{
    public class VBSController : Controller
    {
        public ActionResult Host()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
