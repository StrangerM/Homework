using System;
using System.Collections.Generic;
using System.Linq;
using Task2.BLL;
using Task2.Models;

namespace Task2
{
    class Program
    {
        List<Restaurant> listRestaurants = new List<Restaurant>();
        List<Buyer> listBuyers = new List<Buyer>();
        List<Meal> listMeals = new List<Meal>();
        MealBuilder mealBuilder = new MealBuilder();
        BuyerBuilder buyerBuilder = new BuyerBuilder();
        public static void Main(string[] args)
        {   
            Console.WriteLine("Welome to the service");
            Program program = new Program();
            program.FillInLists();
            while (true)
            {
                Console.WriteLine("If You wanna add meal - input - 0, order meal - 1");
                var readData = Console.ReadLine();
                program.FillInLists(readData);
                Console.ForegroundColor = ConsoleColor.White;
  
            } 
        }
        public void FillInLists(string role) 
        {
            if (role == "0")
            {
                try
                {
                   
                    while (true)
                    { 
                        var meal = mealBuilder.CreateMeal();                         
                        listMeals.Add(meal);
                        meal.Id = listMeals.Count - 1;
                        Console.WriteLine( "If You wanna add another meal press - 1, if not press any button");
                        var key = Console.ReadLine();
                        if (key != "1")
                            return;

                    }

                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }
            }
            if (role == "1")
            {
                try
                {
                    
                    Buyer buyer = new Buyer();
                    buyer = buyerBuilder.CreateBuyer();
                    buyer.Id = listBuyers.Count;
                    DisplayMeal();
                    Console.WriteLine("Please choose some meal using their Id, divide them by coma and press Enter, For example: 1,4,6"  );
                    var order = Console.ReadLine();
                    var orderedList = CreateOrderingList(order);
                    var result = PushOrder(orderedList);
                    if(!result)
                        Console.WriteLine("Please choose only available meal");
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }
             
            }

        }
        public IEnumerable<Meal> CreateOrderingList(string order) 
        {
            var splitOrder = order.Split(',');
            var dataNotExist = splitOrder.Where(x => !listMeals.Any(y => y.Id.ToString() == x));
            if(dataNotExist.Count() != 0) 
            {
                foreach (var item in dataNotExist)
                    Console.WriteLine("Meal with Id- {0} is not exist", item);
            }

           return listMeals.Where(x => splitOrder.Any(y => y == x.Id.ToString()));
        }
        public bool PushOrder(IEnumerable<Meal> meals) 
        {
            var name = String.Empty;
            decimal price = default;
            if (meals.Count() == 0)
                return false;
            foreach(var item in meals) 
            {
                name += item.Name + " ";
                if (item.Discount == 0)
                {
                    item.Discount = 1;
                    price += item.Price;
                }
                else
                {
                    price += (item.Discount / 100 * item.Price);
                }
            }
            Console.WriteLine("Your Order was created successfully");
            Console.WriteLine( "You chose " + name + " "+ "And Sum to paid is" + " "+ price.ToString());
            return true;
        }

        public void FillInLists() 
        {
            listRestaurants.Add(new Restaurant
            {
                Id = 0,
                Name = "Claude Monet",
                Address = "Zankovetska st. 27",
                CellPhone = "8097654312",
               
            });
            listMeals.Add(new Meal
            {
                Id = 0,
                Name = "Fuagra",
                Price = 20,
                Discount = 0,
                RestaurantID = 0
            });

        }
        public void DisplayMeal() 
        {
           if(listMeals.Count == 0)
                Console.WriteLine("Sorry, Now We do not have any meal");
           foreach(var item in listMeals) 
           {        
                var meal = String.Format("Id of meal - {0}, Name of meal - {1}, Price of meal - {2}$, Discount for meal - {3}%," +
                    " Id of restaurant - {4}", item.Id, item.Name, item.Price, item.Discount, item.RestaurantID);
                Console.WriteLine(meal);
           }

        }
    }
}
