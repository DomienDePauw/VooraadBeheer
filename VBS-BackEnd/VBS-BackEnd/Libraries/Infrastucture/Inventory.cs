using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBS_BackEnd.Models 
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
        public Inventory()
        {
           
        }
    }

}