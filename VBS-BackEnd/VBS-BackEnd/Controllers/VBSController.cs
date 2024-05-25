using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Web.UI;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace VBS_BackEnd.Controllers {

    public class VBSController : Controller {

        public ActionResult Host() {
            ViewBag.Title = "Home Page";

            var hostBuilder = new HostBuilder();

            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            string cs = configurationBuilder.GetConnectionString("voorraadbeheerConnectionString");

            return View();
        }
    }
}