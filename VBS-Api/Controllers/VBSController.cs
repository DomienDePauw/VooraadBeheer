﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using VBS_Api.Models;

namespace VBS_Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class VBSController : ControllerBase {
        public readonly IConfiguration _configuration;

        public VBSController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllDishes")]
        public List<Dish> GetDishes() {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("VBSDbConnectionString").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Dish", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Dish> dishes = new List<Dish>();
            if (dt.Rows.Count > 0) {
                foreach (DataRow dataRow in dt.Rows) {
                    string req = (string)dataRow["Requirements"];
                    List<string> reqs = new List<string>();
                    reqs = req.Trim().Split(',').ToList();

                    List<int> quantities = new List<int>();
                    string quantitiy = (string)dataRow["QuantityPer100GramAmount"];
                    quantities = quantitiy.Trim().Split(",").ToList().Select(int.Parse).ToList();

                    Dish dish = new Dish() {
                        Id = (int)dataRow["Id"],
                        Name = (string)dataRow["Name"],
                        PhotoUrl = (string)dataRow["PhotoUrl"],
                        Requirements = reqs,
                        QuantityPer100GramAmount = quantities,
                        UnitInStock = (string)dataRow["UnitInStock"],
                        GroupId = (int)dataRow["GroupId"],
                        SubgroupId = (int)dataRow["SubgroupId"]
                    };

                    dishes.Add(dish);
                }
            }

            da = new SqlDataAdapter("SELECT * FROM Inventory", con);
            dt = new DataTable();
            da.Fill(dt);

            List<Inventory> inventories = new List<Inventory>();
            if (dt.Rows.Count > 0) {
                foreach (DataRow dataRow in dt.Rows) {
                    Inventory inventory = new Inventory() {
                        FoodId = (int)dataRow["FoodId"],
                        Name = (string)dataRow["Name"],
                        PhotoUrl = (string)dataRow["PhotoUrl"],
                        GroupId = (int)dataRow["GroupId"],
                        SubgroupId = (int)dataRow["SubgroupId"],
                        Quantity = (int)dataRow["Quantity"],
                        StockDate = (DateTime)dataRow["StockDate"],
                        ExpiryDate = (DateTime)dataRow["ExpiryDate"]
                    };

                    inventories.Add(inventory);
                }
            }
            dishes = Dish.GetAvailableDishesFromInventory(_configuration.GetConnectionString("VBSDbConnectionString").ToString());
            return dishes;
        }

        [HttpGet]
        [Route("GetAllDishesByGroupId{Id}")]
        public List<DishWithNames> GetDishesByGroupId(int Id) {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("VBSDbConnectionString").ToString());
            string q1 = "SELECT GroupId, SubgroupId FROM Dish WHERE Id = @Id ";
            SqlCommand cmd = new SqlCommand(q1, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //je krijgt van de front End een Id van een Dish.
            //De front End wilt een lijst met alle dishes die dezelfde groupId en subgroupId hebben (inclusief de dish van het gegeven Id)
            //Er zal een nieuwe model moeten gemaakt worden van Dish, zodat de front End niet groupId en subgroupId heeft, maar een group name en subgroup name
            dynamic dishDetails = new { };
            foreach (DataRow dataRow in dt.Rows) {
                dishDetails = new {
                    GroupId = (int)dataRow["GroupId"],
                    SubgroupId = (int)dataRow["SubgroupId"]
                };
            }
            string q2 = "SELECT d.Id, d.Name, d.PhotoUrl, d.Requirements, d.QuantityPer100GramAmount, d.UnitInStock, g.Name AS GroupName, sg.Name AS SubgroupName FROM Dish d JOIN Groups g ON d.GroupId=g.Id JOIN Subgroups sg ON d.SubgroupId = sg.Id WHERE d.GroupId = @GroupId AND SubgroupId = @SubgroupId";
            SqlCommand cmd2 = new SqlCommand(q2, con);
            cmd2.Parameters.AddWithValue("@groupId", dishDetails.GroupId);
            cmd2.Parameters.AddWithValue("@subgroupId", dishDetails.SubgroupId);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            List<DishWithNames> dishes = new List<DishWithNames>();
            foreach (DataRow dataRow in dt2.Rows) {
                DishWithNames newDish = new DishWithNames() {
                    Id = (int)dataRow["Id"],
                    Name = (string)dataRow["Name"],
                    PhotoUrl = (string)dataRow["PhotoUrl"],
                    Requirements = dataRow["Requirements"].ToString().Trim().Split(", ").ToList(),
                    QuantityPer100GramAmount = dataRow["QuantityPer100GramAmount"].ToString().Trim().Split(", ").ToList().Select(int.Parse).ToList(),
                    UnitInStock = (string)dataRow["UnitInStock"],
                    GroupName = (string)dataRow["GroupName"],
                    SubgroupName = (string)dataRow["SubgroupName"]
                };
                dishes.Add(newDish);
            }
            return dishes;
        }
    }
}