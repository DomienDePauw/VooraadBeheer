using System.Data.SqlClient;
using System.Data;

namespace VBS_Api.Models.Inventory_Repo {

    public class InventoryQuery {

        public static List<Inventory> GetAll(SqlConnection con) {
            string query = "SELECT * FROM Inventory";
            SqlCommand command = new SqlCommand(query, con);
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

        public static List<Inventory> GetAllStockDateDesc(SqlConnection con) {
            List<Inventory> allInventories = GetAll(con);
            return allInventories.OrderByDescending(inventory => inventory.StockDate).ToList();
        }

        public static List<Inventory> GetallStockDateAsc(SqlConnection con) {
            List<Inventory> allInventories = GetAll(con);
            return allInventories.OrderBy(inventory => inventory.StockDate).ToList();
        }

        public static List<Inventory> GetallExpiryDateDesc(SqlConnection con) {
            List<Inventory> allInventories = GetAll(con);
            return allInventories.OrderByDescending(inventory => inventory.ExpiryDate).ToList();
        }

        public static List<Inventory> GetallExpiryDateAsc(SqlConnection con) {
            List<Inventory> allInventories = GetAll(con);
            return allInventories.OrderBy(inventory => inventory.ExpiryDate).ToList();
        }

        public static List<Inventory> GetTop5ExpiryDateAsc(SqlConnection con) {
            List<Inventory> allInventories = GetAll(con);
            return allInventories.OrderBy(inventory => inventory.ExpiryDate).Take(5).ToList();
        }
    }
}