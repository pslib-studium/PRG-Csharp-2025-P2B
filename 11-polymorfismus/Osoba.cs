using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_polymorfismus
{
   public class Osoba
    {

        // vypis for

        // PRIVATE atribut (field) - přístupný jen uvnitř této třídy
        private  string _rodneCislo;

        // PROTECTED atribut - přístupný v této třídě a v potomcích
        protected int vek;

        // PUBLIC vlastnosti (properties) - přístupné všude
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        // Vlastnost s private setterem
        public string RodneCislo
        {
            get { return _rodneCislo; }
            private set { 
                if (!OveritRodneCislo(value))
                {
                    throw new ArgumentException("Neplatné rodné číslo.");
                }
                _rodneCislo = value; }
        }

        // Konstruktor
        public Osoba(string jmeno, string prijmeni, string rodneCislo, int vek)
        {
            if (!OveritRodneCislo(rodneCislo))
            {
                throw new ArgumentException("Neplatné rodné číslo.");
            }

            Jmeno = jmeno;
            Prijmeni = prijmeni;
            _rodneCislo = rodneCislo;
            this.vek = vek;
        }              

        // OVERRIDE ToString()
        public override string ToString()
        {
            return $"{Jmeno} {Prijmeni}";
        }

        public static bool OveritRodneCislo(string rc)
        {
            if (string.IsNullOrWhiteSpace(rc))
                return false;

            // RČ bez lomítka musí mít 9 nebo 10 číslic
            if (rc.Length != 9 && rc.Length != 10)
                return false;

            // Musí obsahovat jen číslice
            if (!rc.All(char.IsDigit))
                return false;

            // Kontrola dělitelnosti 11
            if (!long.TryParse(rc, out long cislo))
                return false;

            return cislo % 11 == 0;
        }

    }
}
