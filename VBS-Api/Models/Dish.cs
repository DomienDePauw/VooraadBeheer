using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using VBS_Api.Models.Dish_Repo;
using VBS_Api.Models.Inventory_Repo;

namespace VBS_Api.Models {

    public class Dish {

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Requirements { get; set; }
        public List<int> QuantityPer100GramAmount { get; set; }
        public string UnitInStock { get; set; }
        public int GroupId { get; set; }
        public int SubgroupId { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Method to get all available dishes from all ingredients in inventory
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public static List<Dish> GetAvailableDishesFromInventory(SqlConnection con) {
            // Helper properties
            List<Dish> allDishes = DishQuery.GetAll(con);
            List<Inventory> allInventories = InventoryQuery.GetAll(con);
            List<Dish> availableDishes = new List<Dish>();

            foreach (Dish dish in allDishes) {
                bool isDishAvailable = true;

                // Get requirements and quantities from all dishes and put them in a dictionary
                Dictionary<string, int> requirementsFromDishes = new Dictionary<string, int>();
                for (int i = 0; i < dish.Requirements.Count; i++) {
                    List<string> reqs = dish.Requirements[i].Trim().Split(", ").ToList();
                    List<int> quantities = dish.QuantityPer100GramAmount[i].ToString().Trim().Split(", ").ToList().Select(int.Parse).ToList();
                    for (int j = 0; j < reqs.Count; j++)
                        requirementsFromDishes.Add(reqs[j], quantities[j]);
                }

                // Check if all required products exists in inventory
                List<string> inventoryNames = allInventories.Select(inventory => inventory.Name).ToList();
                List<string> requiredProductNames = requirementsFromDishes.Keys.ToList();
                foreach (string requiredProductName in requiredProductNames) {
                    if (!inventoryNames.Contains(requiredProductName)) {
                        isDishAvailable = false;
                        break;
                    }
                }
                if (!isDishAvailable) continue;

                // Check if required quantities are available in inventory
                foreach (Inventory inventory in allInventories) {
                    string inventoryProductName = inventory.Name.ToLower();
                    int inventoryProductQuantity = inventory.Quantity;
                    foreach (KeyValuePair<string, int> requirement in requirementsFromDishes) {
                        string requiredProductName = requirement.Key.ToLower();
                        if (inventoryProductName != requiredProductName) continue; // Skip if product name doesn't match
                        int requiredProductQuantity = requirement.Value;
                        if (inventoryProductQuantity < requiredProductQuantity) {
                            isDishAvailable = false;
                            break;
                        }
                    }
                    if (!isDishAvailable) break;
                }
                if (!isDishAvailable) continue;
                else availableDishes.Add(dish);
            }
            return availableDishes;
        }

        #endregion Methods
    }
}