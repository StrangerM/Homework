using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using Task2.BLL;
using Task2.Models;
using Castle.MicroKernel.Registration;
using Task2.DI;

namespace Task2
{
    class Program
    {
      

        public static void Main(string[] args)
        {

            Logger.DisplayData("Welome to the service");

            var containerForBuyer = new WindsorContainer();

            containerForBuyer.Register(Component.For<DIContainer>());

            containerForBuyer.Register(Component.For<IRepository>()
                             .ImplementedBy<BuyerBuilder>().LifestyleSingleton());

            var meal = MealBuilder.GetInstance();
   
            var buyer = containerForBuyer.Resolve<DIContainer>();

            while (true)
            {    
                Logger.DisplayData("If You wanna add meal - input - 0, order meal - 1");
                var readData = Logger.ReadData();
                buyer.InitiateServiceMethods(readData);
                meal.FillInLists(readData);
                Console.ForegroundColor = ConsoleColor.White;
            } 
 
        }
 
    }
}
