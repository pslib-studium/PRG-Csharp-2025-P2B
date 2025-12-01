using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_statika
{
    public static class Numerics
    {
        // statické třídy nemohou mít konstruktory!

        // Statická metoda pro sčítání dvou celých čísel
        public static int Addition(int a, int b)
        {
            return a + b;
        }

        // Statická metoda pro odečítání dvou celých čísel
        public static int Subtraction(int a, int b)
        {
            return a - b;
        }

        // Statická metoda pro násobení dvou celých čísel
        public static int Multiplication(int a, int b)
        {
            return a * b;
        }

        // Statická metoda pro dělení celých čísel (celočíselné dělení)
        public static int Division(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Dělení nulou není povoleno!");
            return a / b;
        }
    }

}
