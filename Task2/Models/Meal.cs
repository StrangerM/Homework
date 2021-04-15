﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    public class Meal
    {
        public int MealID { get; set; }
        public string NameOfMeal { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int? RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
