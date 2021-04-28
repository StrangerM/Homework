using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.BLL
{
    public static class Logger
    {
        public static void DisplayData(string data)
        {
            Console.WriteLine(data);
        }
        public static string ReadData()
        {
            return Console.ReadLine();
        }
    }
}
