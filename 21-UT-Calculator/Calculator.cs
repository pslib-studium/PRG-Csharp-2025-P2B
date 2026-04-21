using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_UT_Calculator
{
    public class Calculator
    {
        public double Addition(double x, double y)
        {

            return x + y;
        }

        public double Substraction(double x, int y) { return x - y; }

        public double Multiplication(double x, double y)
        {

            // if (x == 1) return 100; chyba funkce

            return x * y;

        }

        public double Divide(double x, double y)
        {

            if (y == 0) throw new ArgumentException("Nelze dělit nulou!");

            return x / y;
        }



    }
}
