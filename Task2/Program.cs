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

            Console.WriteLine("Welome to the service");

            var containerForBuyer = new WindsorContainer();

            containerForBuyer.Register(Component.For<DIContainer>());

            containerForBuyer.Register(Component.For<IRepository>()
                             .ImplementedBy<BuyerBuilder>().LifestyleSingleton());

            var buyer = containerForBuyer.Resolve<DIContainer>();

            var meal = MealBuilder.GetInstance();

            while (true)
            {    
                Console.WriteLine("If You wanna add meal - input - 0, order meal - 1");
                var readData = Console.ReadLine();
                buyer.InitiateServiceMethods(readData);
                meal.FillInLists(readData);
                Console.ForegroundColor = ConsoleColor.White;
  
            } 
 
        }
 
    }
}
