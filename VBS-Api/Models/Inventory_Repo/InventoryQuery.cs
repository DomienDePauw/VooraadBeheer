using System.Data.SqlClient;
using System.Data;

namespace VBS_Api.Models.Inventory_Repo {

    public class InventoryQuery {

        public static List<Inventory> GetAll(string connectionString) {
            string query = "SELECT * FROM Inventory";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            List<Inventory> inventories = new List<Inventory>();
            foreach (DataRow dataRow in dataTable.Rows) {
                Inventory newInventory = new Inventory() {
                    FoodId = (int)dataRow["FoodId"],
                    Name = (string)dataRow["Name"],
                    PhotoUrl = (string)dataRow["PhotoUrl"],
                    GroupId = (int)dataRow["GroupId"],
                    SubgroupId = (int)dataRow["SubgroupId"],
                    Quantity = (int)dataRow["Quantity"],
                    StockDate = (DateTime)dataRow["StockDate"],
                    ExpiryDate = (DateTime)dataRow["ExpiryDate"]
                };
                inventories.Add(newInventory);
            }
            return inventories;
        }
    }
}