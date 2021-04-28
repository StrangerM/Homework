using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.BLL
{
    public class BuyerBuilder :  IRepository
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
                Logger.DisplayData("Before to order of meal needs to fill in some data");
                Logger.DisplayData("Please input your Name  and press Enter");
                NewBuyer.Name = Logger.ReadData();
                if (Validator.ConvertTo(NewBuyer.Name))
                {
                    Logger.DisplayData("Name can not be Empty");
                    continue;
                }
                Logger.DisplayData("Please input your Last Name  and press Enter");
                NewBuyer.LastName = Logger.ReadData();
                if (Validator.ConvertTo(NewBuyer.LastName))
                {
                    Logger.DisplayData("Last Name can not be Empty");
                    continue;
                }
                Logger.DisplayData("Please input your Address and press Enter");
                NewBuyer.Address = Logger.ReadData();
                if (Validator.ConvertTo(NewBuyer.Address))
                {
                    Logger.DisplayData("Address can not be Empty");
                    continue;
                }
                Logger.DisplayData("Please input your CellPhone, use format - 809........ and press Enter");
                var cellPhone = Logger.ReadData();
                int temp = 0;
                if (!Validator.ConvertTo(cellPhone, out temp))
                {
                    Logger.DisplayData("Please input number in the correct format");
                    continue;
                }
                NewBuyer.CellPhone = temp.ToString();
                Console.ForegroundColor = ConsoleColor.Green;
                Logger.DisplayData("Now you can choose meal");
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
                    Logger.DisplayData("Please choose some meal using their Id, divide them by coma and press Enter, For example: 1,4,6");
                    var order = Logger.ReadData();
                    var orderedList = mealBuilder.CreateOrderingList(order);
                    var result = mealBuilder.PushOrder(orderedList);
                    if (!result)
                        Logger.DisplayData("Please choose only available meal");
                }
                catch (Exception x)
                {
                    Logger.DisplayData(x.Message);
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
