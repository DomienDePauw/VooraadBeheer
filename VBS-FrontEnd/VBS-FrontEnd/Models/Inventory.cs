﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBS_FrontEnd.Models
{
    public class Inventory
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int GroupId { get; set; }
        public int SubgroupId { get; set; }
        public int Quantity { get; set; }
        public DateTime StockDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        // Constructor
        public Inventory(int foodId, string name, string photoUrl, int groupId, int subgroupId, int quantity, DateTime stockDate, DateTime expiryDate)
        {
            FoodId = foodId;
            Name = name;
            PhotoUrl = photoUrl;
            GroupId = groupId;
            SubgroupId = subgroupId;
            Quantity = quantity;
            StockDate = stockDate;
            ExpiryDate = expiryDate;
        }
    }
}