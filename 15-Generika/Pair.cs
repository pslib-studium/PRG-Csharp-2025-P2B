using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Generika
{
    /// <summary>
    /// Jednoduchá generická třída se dvěma typovými parametry
    /// </summary>
    /// <typeparam name="TKey">Typ klíče</typeparam>
    /// <typeparam name="TValue">Typ hodnoty</typeparam>
    public class Pair<TKey, TValue>
    {
        // Vlastnosti pro klíč a hodnotu
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        // Konstruktor
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        // Přepsání ToString pro výpis
        public override string ToString()
        {
            return $"Key: {Key}, Value: {Value}";
        }
    }

}
