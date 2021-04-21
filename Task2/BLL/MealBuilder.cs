using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.BLL
{
    public class MealBuilder
    {
        
        public Meal CreateMeal()
        {
            Meal NewMeal = new Meal();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please add some meal");
                Console.WriteLine("Please input  Name  and press Enter");
                NewMeal.Name = Console.ReadLine();
                if (String.IsNullOrEmpty(NewMeal.Name))
                {
                    Console.WriteLine("Name can not be Empty");
                    continue;
                }
                Console.WriteLine("Please input Price $ (only number) and press Enter. Use . separator if need");
                
                var price = Console.ReadLine();
                decimal temp = 0;
                if (!decimal.TryParse(price, out temp))
                {
                    Console.WriteLine("Please input number in correct format");
                    continue;
                }
                NewMeal.Price = temp;
                Console.WriteLine("Please input Discount % (only number) if there is no discount -input - 0 and press Enter");

                var dicount = Console.ReadLine();
                var tempDiscount = 0;
                if (!Int32.TryParse(dicount, out tempDiscount))
                {
                    Console.WriteLine("Please input number in correct format");
                    continue;
                }
                NewMeal.Discount = tempDiscount;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your Meal was add to DB successfuly");
                return NewMeal;
            }

        }

    }
}
