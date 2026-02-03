using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Generika
{
    internal class Printer
    {
        public static void Print<T>(T value)
        {
            Console.WriteLine($"hodnota: {value}");
        }
    }
}
