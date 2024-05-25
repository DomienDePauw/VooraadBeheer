using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBS_BackEnd.Models 
{
    public class Dish
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int FoodGroupId { get; set; }
        public int SubGroupId { get; set; }
        public int Quantity { get; set; }
        public DateTime StockDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Dish(int foodId, string name, string photoUrl, int foodGroupId, int subGroupId, int quantity, DateTime stockDate, DateTime expiryDate)
        {
            FoodId = foodId;
            Name = name;
            PhotoUrl = photoUrl;
            FoodGroupId = foodGroupId;
            SubGroupId = subGroupId;
            Quantity = quantity;
            StockDate = stockDate;
            ExpiryDate = expiryDate;
        }

    }
}