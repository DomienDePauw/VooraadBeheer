using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VBS.Db;
using VBS_BackEnd.Models;
using AcceptVerbsAttribute = System.Web.Http.AcceptVerbsAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace VBS_BackEnd.Controllers
{
    public class VBSController : ApiController
    {
        private readonly IHost _host;
        private IConfiguration _configuration;
        public VBSController()
        {
            var hostBuilder = new HostBuilder();

            // Setup van configuratie:

            hostBuilder = (HostBuilder)hostBuilder.ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                configurationBuilder.AddJsonFile("C:\\Users\\deans\\Documents\\GitHub\\VooraadBeheer\\VBS-BackEnd\\VBS-BackEnd\\Controllers\\appsettings.json", optional: false, reloadOnChange: true);
                // Niet optioneel: config bestand moet er staan!
                // reload on change: zonder de app te herstarten is een aangepast configuratiebestand opgeladen
                configurationBuilder.AddEnvironmentVariables(); // bijvoorbeeld SET X=Y
            })
                .ConfigureServices((context, services) =>
                {
                    // DI Db registratie:
                    // ------------------
                    var cs = context.Configuration.GetConnectionString("VBSDbConnectionString");
                    if (!string.IsNullOrEmpty(cs))
                    {
                        VBSDb _repository = new VBSDb(cs);
                        services.AddSingleton<VBSDb>(_repository);
                    }
                });
            _host = hostBuilder.Build();
        }

        [Route("api/Dishes")]
        [AcceptVerbs("Get")]
        public List<Dish> GetDishes()
        {
            _host.Start();
            List<Dish> dishes = _host.Services.GetService<VBSDb>().Dish.Query.All();
            return dishes;
        }
    }
}
