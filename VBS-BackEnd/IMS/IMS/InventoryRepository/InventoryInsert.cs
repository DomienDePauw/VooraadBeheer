using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using VBS_BackEnd.Models;

namespace InventoryManagementSystem.InventoryRepository
{
    public class InventoryInsert
    {
        private string cs = WebConfigurationManager.ConnectionStrings["ImsConnectionstring"].ConnectionString;

        public bool InsertInventoryItem(Inventory inventory)
        {
            bool success = false;
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string sqlQuery = @"
                    INSERT INTO Inventory 
                    (FoodId, Name, PhotoUrl, GroupId, SubgroupId, Quantity, StockDate, ExpiryDate) 
                    VALUES 
                    (@FoodId, @Name, @PhotoUrl, @GroupId, @SubgroupId, @Quantity, @StockDate, @ExpiryDate)";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@FoodId", inventory.FoodId);
                        cmd.Parameters.AddWithValue("@Name", inventory.Name);
                        cmd.Parameters.AddWithValue("@PhotoUrl", inventory.PhotoUrl);
                        cmd.Parameters.AddWithValue("@GroupId", inventory.GroupId);
                        cmd.Parameters.AddWithValue("@SubgroupId", inventory.SubgroupId);
                        cmd.Parameters.AddWithValue("@Quantity", inventory.Quantity);
                        cmd.Parameters.AddWithValue("@StockDate", inventory.StockDate);
                        cmd.Parameters.AddWithValue("@ExpiryDate", inventory.ExpiryDate);

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
                // Log exception details if needed
                Console.WriteLine(ex.ToString());
            }

            return success;
        }
    }
}
