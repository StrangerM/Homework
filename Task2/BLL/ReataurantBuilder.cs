using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.BLL
{
    public class RestaurantBuilder
    {
        
        public Restaurant CreateRestaurant()
        {
            Restaurant NewRestaurant = new Restaurant();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Before registration of new restaurant needs to fill in some data");
                Console.WriteLine("Please input Name of Restaurant and press Enter");
                NewRestaurant.Name = Console.ReadLine();
                if (String.IsNullOrEmpty(NewRestaurant.Name))
                {
                    Console.WriteLine("Name can not be Empy");
                    continue;
                }
                Console.WriteLine("Please input Address of Restaurant and press Enter");
                NewRestaurant.Address = Console.ReadLine();
                if (String.IsNullOrEmpty(NewRestaurant.Address))
                {
                    Console.WriteLine("Address can not be Empy");
                    continue;
                }
                Console.WriteLine("Please input CellPhone, use format - 809........ and press Enter");
                var cellPhone = Console.ReadLine();
                var temp = 0;
                if(!Int32.TryParse(cellPhone, out temp)) 
                {
                    Console.WriteLine("Please input number in correct format");
                    continue;
                }
                NewRestaurant.CellPhone = temp.ToString();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your Restaurant was registred successfuly");
                return NewRestaurant;
            }
            
        }
    }
}
