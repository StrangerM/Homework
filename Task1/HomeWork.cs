using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class HomeWork
    {
        private decimal GetFullPrice(
                                    IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            decimal fullPrice = default;         
            string street = "";
            decimal extraDicsount = 1;
            if (destinations.Count() != clients.Count() && prices.Count() != currencies.Count())
            {
                return fullPrice;
            }

                for (int x = 0; x < destinations.Count(); x++) 
                {
                    decimal waynStreet = destinations.ElementAt(x).Contains("Wayne Street") ? 10 : 0;
                    decimal northStreet = destinations.ElementAt(x).Contains("North Heather Street") ? -5.36m : 0;
                    decimal currency = currencies.ElementAt(x).Contains("EUR") ? 1.19m : 1;

                    var tempforInfants = infantsIds.Where(y => y == x);
                    decimal discountForInfants = tempforInfants.Any() ? 0.5m : 1;
                    var tempforChildren = childrenIds.Where(y => y == x);
                    decimal discountForchildren = tempforChildren.Any() ? 0.25m : 1;
                    int start = destinations.ElementAt(x).IndexOf(' ');
                    int end = destinations.ElementAt(x).IndexOf(',') - 1;

                        string nextstreet = destinations.ElementAt(x).Substring(start, end);
                        if (nextstreet == street)
                            extraDicsount = 0.15m;
                        extraDicsount = 1;

                     street = destinations.ElementAt(x).Substring(start, end);
                    fullPrice += (prices.ElementAt(x) + waynStreet + northStreet) * extraDicsount * currency * discountForchildren * discountForInfants;

                }
            
            Console.WriteLine(fullPrice);
            return fullPrice;
        }

        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
    }
}
