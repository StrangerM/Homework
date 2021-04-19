using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public Buyer()
        {
            Meals = new List<Meal>();
        }

    }
}
