using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using VBS_BackEnd.Models;

namespace VBS_BackEnd.DishRepository
{
    public class DishInsert
    {
        private string cs = WebConfigurationManager.ConnectionStrings["ImsConnectionstring"].ConnectionString;

        public bool InsertDish(Dish dish)
        {
            bool success = false;
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string sqlQuery = @"
                    INSERT INTO Dishes 
                    (Name, PhotoUrl, Requirements, QuantityPer100GramAmount, UnitInStock, GroupId, SubgroupId) 
                    VALUES 
                    (@Name, @PhotoUrl, @Requirements, @QuantityPer100GramAmount, @UnitInStock, @GroupId, @SubgroupId)";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", dish.Name);
                        cmd.Parameters.AddWithValue("@PhotoUrl", dish.PhotoUrl);
                        cmd.Parameters.AddWithValue("@Requirements", dish.Requirements);
                        cmd.Parameters.AddWithValue("@QuantityPer100GramAmount", dish.QuantityPer100GramAmount);
                        cmd.Parameters.AddWithValue("@UnitInStock", dish.UnitInStock);
                        cmd.Parameters.AddWithValue("@GroupId", dish.GroupId);
                        cmd.Parameters.AddWithValue("@SubgroupId", dish.SubgroupId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return success;
        }
    }
}
