using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using VBS_Api.Controllers;

namespace VBS_Api.Models.Dish_Repo {

    public class DishQuery {

        public static List<Dish> GetAll(SqlConnection con) {
            string query = "SELECT * FROM Dish";          
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            List<Dish> dishes = new List<Dish>();
            foreach (DataRow dataRow in dataTable.Rows) {
                Dish newDish = new Dish() {
                    Id = (int)dataRow["Id"],
                    Name = (string)dataRow["Name"],
                    PhotoUrl = (string)dataRow["PhotoUrl"],
                    Requirements = dataRow["Requirements"].ToString().Trim().Split(", ").ToList(),
                    QuantityPer100GramAmount = dataRow["QuantityPer100GramAmount"].ToString().Trim().Split(",").ToList().Select(int.Parse).ToList(),
                    UnitInStock = (string)dataRow["UnitInStock"],
                    GroupId = (int)dataRow["GroupId"],
                    SubgroupId = (int)dataRow["SubgroupId"]
                };
                dishes.Add(newDish);
            }
            return dishes;
        }
    }
}