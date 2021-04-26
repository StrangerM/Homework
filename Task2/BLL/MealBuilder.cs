using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.BLL
{
    public class MealBuilder : ICreatable, IRepository
    {
        IList<Meal> container;

       private static readonly MealBuilder mealBuilder = new MealBuilder();

        public MealBuilder() 
        {
            container = new List<Meal>();
            FillInLists();
        }

        public object Create()
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

        public static MealBuilder GetInstance()
        {
            return mealBuilder;
        }

        public void FillInLists(string role)
        {

            if (role == "0")
            {
                try
                {

                    while (true)
                    {
                        var meal = (Meal)this.Create();
                        container.Add(meal);
                        meal.Id = container.Count() - 1;
                        Console.WriteLine("If You wanna add another meal press - 1, if not press any button");
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
        }

        public void FillInLists()
        {
            container.Add(new Meal
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
            if (container.Count() == 0)
                Console.WriteLine("Sorry, Now We do not have any meal");
            foreach (var item in container)
            {
                var meal = String.Format("Id of meal - {0}, Name of meal - {1}, Price of meal - {2}$, Discount for meal - {3}%," +
                    " Id of restaurant - {4}", item.Id, item.Name, item.Price, item.Discount, item.RestaurantID);
                Console.WriteLine(meal);
            }

        }

        public bool PushOrder(IEnumerable<Meal> meals)
        {
            var name = String.Empty;
            decimal price = default;
            if (meals.Count() == 0)
                return false;
            foreach (var item in meals)
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
            Console.WriteLine("You chose " + name + " " + "And Sum to pay is" + " " + price.ToString());
            return true;
        }

        public IEnumerable<Meal> CreateOrderingList(string order)
        {
            var splitOrder = order.Split(',');
            var dataNotExist = splitOrder.Where(x => !container.ToList().Any(y => y.Id.ToString() == x));
            if (dataNotExist.Count() != 0)
            {
                foreach (var item in dataNotExist)
                    Console.WriteLine("Meal with Id- {0} is not exist", item);
            }

            return container.ToList().Where(x => splitOrder.Any(y => y == x.Id.ToString()));
        }
    }
}
