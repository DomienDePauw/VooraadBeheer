﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBS_BackEnd.Models;

public class Dish
{
    public int DishId { get; set; }
    public string Name { get; set; }
    public string PhotoUrl { get; set; }
    public string FoodRequirements { get; set; }
    public decimal QuantityPer100GramAmount { get; set; }
    public int UnitInStock { get; set; }
    public int FoodGroupId { get; set; }
    public int SubgroupId { get; set; }

    public Dish(int dishId, string name, string photoUrl, string foodRequirements, decimal quantityPer100GramAmount, int unitInStock, int foodGroupId, int subgroupId )
    {
        DishId = dishId;
        Name = name;
        PhotoUrl = photoUrl;
        FoodRequirements = foodRequirements;
        QuantityPer100GramAmount = quantityPer100GramAmount;
        UnitInStock = unitInStock;
        FoodGroupId = foodGroupId;
        SubgroupId = subgroupId;
    }

}