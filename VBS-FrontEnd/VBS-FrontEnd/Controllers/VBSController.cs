﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VBS_FrontEnd.Controllers
{
    public class VBSController : Controller
    {
        public ActionResult Home()
        {
            List<string> list = new List<string>();
            list.Add("u mama");
            list.Add("u pzpz");
            list.Add("u qzdqzd");
            list.Add("u gggg");
            list.Add("u rikkie");
            return View(list);
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