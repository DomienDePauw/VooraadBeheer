using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using VBS_BackEnd.Models;

namespace InventoryManagementSystem.DishRepository
{
    public class DishQuery
    {
        private string cs = WebConfigurationManager.ConnectionStrings["ImsConnectionstring"].ConnectionString;

        public List<Dish> GetAllDishes()
        {
            List<Dish> dishes = new List<Dish>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Dishes";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dish dish = new Dish(
                                    id: Convert.ToInt32(reader["Id"]),
                                    name: reader["Name"].ToString(),
                                    photoUrl: reader["PhotoUrl"].ToString(),
                                    requirements: reader["Requirements"].ToString(),
                                    quantityPer100GramAmount: reader["QuantityPer100GramAmount"].ToString(),
                                    unitInStock: reader["UnitInStock"].ToString(),
                                    groupId: Convert.ToInt32(reader["GroupId"]),
                                    subgroupId: Convert.ToInt32(reader["SubgroupId"])
                                );

                                dishes.Add(dish);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return dishes;
        }
    }
}
