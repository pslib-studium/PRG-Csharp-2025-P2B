using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_trida
{
public class Kruh
    {
        // -------------------------------------------------------------------------
        // 1. Atribut 
        // -------------------------------------------------------------------------

        private double _polomer; // atribut

        // -------------------------------------------------------------------------
        // 2. Vlastnost pouze pro čtení (výpočet obsahu)
        // -------------------------------------------------------------------------

        public double Obsah
        {
            get { return Math.PI * _polomer * _polomer; }
        }

        // -------------------------------------------------------------------------
        // 3. Vlastnost s kontrolou přiřazení
        // -------------------------------------------------------------------------

        /// <summary>
        /// Poloměr kruhu. Při přiřazení se kontroluje, zda je hodnota kladná.
        /// </summary>
        public double Polomer
        {
            get { return _polomer; }
            set
            {
                if (value > 0)
                    _polomer = value;
                else
                    throw new ArgumentException("Poloměr musí být větší než 0.");
            }
        }


        // -------------------------------------------------------------------------
        // 4. Konstruktor
        // -------------------------------------------------------------------------

        /// <summary>
        /// Inicializuje nový objekt kruhu s daným (nebo výchozím) poloměrem.
        /// </summary>
        /// <param name="polomer">Počáteční hodnota poloměru (default: 1.0)</param>
        public Kruh(double polomer = 1.0)
        {
            // Použití vlastnosti zajistí kontrolu hodnoty
            Polomer = polomer;
        }


        // -------------------------------------------------------------------------
        // 5. Metody třídy
        // -------------------------------------------------------------------------

        /// <summary>
        /// Vrací textovou informaci o poloměru a obsahu kruhu.
        /// </summary>
        public string info()
        {
            return $"polomer: {_polomer}, obsah: {Obsah}";
        }

        /// <summary>
        /// Změní velikost kruhu vynásobením poloměru zadaným koeficientem.
        /// </summary>
        /// <param name="koeficient">Číslo, kterým se poloměr násobí (např. 2 → dvojnásobný)</param>
        public void zmenVelikost(double koeficient)
        {
            _polomer = _polomer * koeficient;
        }
    }
}


