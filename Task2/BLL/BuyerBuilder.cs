using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.BLL
{
    public class BuyerBuilder : ICreatable, IRepository
    {
        IList<Buyer> listBuyers;


        public BuyerBuilder() 
        {
            listBuyers = new List<Buyer>();
            FillInLists();
        }

        public object Create()
        {
            Buyer NewBuyer = new Buyer();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Before to order of meal needs to fill in some data");
                Console.WriteLine("Please input your Name  and press Enter");
                NewBuyer.Name = Console.ReadLine();
                if (String.IsNullOrEmpty(NewBuyer.Name))
                {
                    Console.WriteLine("Name can not be Empty");
                    continue;
                }
                Console.WriteLine("Please input your Last Name  and press Enter");
                NewBuyer.LastName = Console.ReadLine();
                if (String.IsNullOrEmpty(NewBuyer.LastName))
                {
                    Console.WriteLine("Last Name can not be Empty");
                    continue;
                }
                Console.WriteLine("Please input your Address and press Enter");
                NewBuyer.Address = Console.ReadLine();
                if (String.IsNullOrEmpty(NewBuyer.Address))
                {
                    Console.WriteLine("Address can not be Empty");
                    continue;
                }
                Console.WriteLine("Please input your CellPhone, use format - 809........ and press Enter");
                var cellPhone = Console.ReadLine();
                var temp = 0;
                if (!Int32.TryParse(cellPhone, out temp))
                {
                    Console.WriteLine("Please input number in the correct format");
                    continue;
                }
                NewBuyer.CellPhone = temp.ToString();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Now you can choose meal");
                return NewBuyer;
            }

        }

        public void FillInLists(string role)
        {
                MealBuilder mealBuilder = MealBuilder.GetInstance();
                BuyerBuilder buyerBuilder = new BuyerBuilder();
            if (role == "1")
            {
                try
                {
                    var buyer = (Buyer)buyerBuilder.Create();
                    buyer.Id = listBuyers.Count();
                    mealBuilder.DisplayMeal();
                    Console.WriteLine("Please choose some meal using their Id, divide them by coma and press Enter, For example: 1,4,6");
                    var order = Console.ReadLine();
                    var orderedList = mealBuilder.CreateOrderingList(order);
                    var result = mealBuilder.PushOrder(orderedList);
                    if (!result)
                        Console.WriteLine("Please choose only available meal");
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }
            }
         
        }

        public void FillInLists()
        {
            listBuyers.Add(new Buyer
            {
                Id = 0,
                Name = "Ivan",
                LastName = "Pupkin",
                Address = "Zankovetska st. 27",
                CellPhone = "8097654312",

            });
        }

    }
}
