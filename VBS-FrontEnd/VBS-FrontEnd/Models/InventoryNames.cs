using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBS_FrontEnd.Models
{
    public class InventoryNames {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string GroupName { get; set; }
        public string SubgroupName { get; set; }
        public int Quantity { get; set; }
        public DateTime StockDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}