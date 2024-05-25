using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace InventoryManagementSystem.InventoryRepository
{
    public class InventoryDelete
    {
        private string cs = WebConfigurationManager.ConnectionStrings["ImsConnectionstring"].ConnectionString;

        public bool DeleteInventoryItem(int foodId)
        {
            bool success = false;
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string sqlQuery = "DELETE FROM Inventory WHERE FoodId = @FoodId";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@FoodId", foodId);

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
