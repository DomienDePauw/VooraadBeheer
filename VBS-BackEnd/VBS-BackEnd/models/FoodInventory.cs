using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBS_BackEnd.Models 
{
    public class FoodInventory
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string FoodRequirements { get; set; }
        public decimal QuantityPer100GramAmount { get; set; }
        public int UnitInStock { get; set; }
        public int FoodGroupId { get; set; }
        public int SubGroupId { get; set; }

        public FoodInventory(int dishId, string name, string photoUrl, string foodRequirements, decimal quantityPer100GramAmount,
            int unitInStock, int foodGroupId, int subGroupId)
        {
            DishId = dishId;
            Name = name;
            PhotoUrl = photoUrl;
            FoodRequirements = foodRequirements;
            QuantityPer100GramAmount = quantityPer100GramAmount;
            UnitInStock = unitInStock;
            FoodGroupId = foodGroupId;
            SubGroupId = subGroupId;
        }
    }

}