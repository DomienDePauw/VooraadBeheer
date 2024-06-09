using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using VBS_Api.Models.Dish_Repo;

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

        public static List<Dish> GetAvailableDishesFromInventory(string connectionString, List<Inventory> inventories, List<Dish> dishes) {
            List<Dish> allDishes = DishQuery.GetAll(connectionString);

            return dishes;
        }

        #endregion Methods
    }
}