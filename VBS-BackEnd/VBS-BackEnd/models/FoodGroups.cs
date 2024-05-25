using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBS_BackEnd.Models
{
    public class FoodGroups
    {
        public int FoodGroupId { get; set; }
        public string Name { get; set; }

        public FoodGroups(int foodGroupId, string name)
        {
            FoodGroupId = foodGroupId;
            Name = name;
        }
    }
}