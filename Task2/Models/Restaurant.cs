using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
   public class Restaurant
   {
        public int RestaurantID { get; set; }
        public string NameOfRestaurant { get; set; }
        public string AddressOfRestaurant{ get; set; }
        public string CellPhoneNumberOfRestaurant { get; set; }

        public ICollection<Meal> Meals { get; set; }
        public Restaurant()
        {
            Meals = new List<Meal>();
        }

    }
}
