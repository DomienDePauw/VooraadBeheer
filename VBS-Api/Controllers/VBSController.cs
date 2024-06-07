using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using VBS_Api.Models;

namespace VBS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VBSController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public VBSController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllDishes")]
        public List<Dish> GetDishes()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("VBSDbConnectionString").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Dish", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Dish>dishes = new List<Dish>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    Dish dish = new Dish()
                    {
                        Id = (int)dataRow["Id"],
                        Name = (string)dataRow["Name"],
                        PhotoUrl = (string)dataRow["PhotoUrl"],
                        Requirements = (string)dataRow["Requirements"],
                        QuantityPer100GramAmount = (string)dataRow["QuantityPer100GramAmount"],
                        UnitInStock = (string)dataRow["UnitInStock"],
                        GroupId = (int)dataRow["GroupId"],
                        SubgroupId = (int)dataRow["SubgroupId"]
                    };

                    dishes.Add(dish);
                }
            }
            return dishes;
        }
    }
}
