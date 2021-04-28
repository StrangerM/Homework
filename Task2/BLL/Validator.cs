using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.BLL
{
    public static class Validator
    {

        public static bool ConvertTo(string input, out int result) 
        {
            return Int32.TryParse(input, out result);
        }

        public static bool ConvertTo(string input, out decimal tempDecimal)
        {
            return Decimal.TryParse(input, out tempDecimal);
        }

        public static bool ConvertTo(string input)
        {
            return input == String.Empty;
        }
    }
}
