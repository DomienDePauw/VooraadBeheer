using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace InventoryManagementSystem.DishRepository
{
    public class DishDelete
    {
        private string cs = WebConfigurationManager.ConnectionStrings["ImsConnectionstring"].ConnectionString;

        public bool DeleteDish(int id)
        {
            bool success = false;
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string sqlQuery = "DELETE FROM Dishes WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
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
