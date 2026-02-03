using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _16_Generika
{
    /// <summary>
    /// Generická třída pro sčítání číselných hodnot podporující všechny číselné typy implementující INumber<T>
    /// </summary>
    /// <typeparam name="T">Typ musí implementovat rozhraní INumber<T> (int, double, decimal, atd.)</typeparam>
    class Scitac<T> where T : INumber<T>
    {
        protected T _value;
        public T Value { get { return _value; } }

        public Scitac(T value)
        {
            _value = value;
        }

        public T secti(T number)
        {
            return _value + number; // Vrací součet aktuální hodnoty a parametru
        }

    }
}