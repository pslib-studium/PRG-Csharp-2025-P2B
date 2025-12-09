using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_polymorfismus
{
    public class Zamestnanec : Osoba
    {
        // PRIVATE atribut
        private int _zakladniPlat; // Kč za hodinu

        // PUBLIC vlastnosti
        public string Pozice { get; set; }

        // Vlastnost se zapouzdřením (encapsulation)
        // ZakladniPlat představuje hodinovou sazbu v Kč
        public int ZakladniPlat
        {
            get { return _zakladniPlat; }
            set
            {
                if (value >= 0)
                    _zakladniPlat = value;
                else
                    throw new ArgumentException("Plat nemůže být záporný!");
            }
        }

        // Konstruktor
        // zakladniPlat = hodinová sazba v Kč
        public Zamestnanec(string jmeno, string prijmeni, string rodneCislo, int vek,
                          string pozice, int zakladniPlat)
            : base(jmeno, prijmeni, rodneCislo, vek)
        {
            Pozice = pozice;
            ZakladniPlat = zakladniPlat; // Hodinová sazba
        }

        // VIRTUÁLNÍ metoda - může být dále přepsána
        // Výpočet: hodinová sazba × počet odpracovaných hodin
        public virtual double VypoctiPlat(double odpracovaneHodiny = 40)
        {
            if (odpracovaneHodiny < 0)
                throw new ArgumentException("Počet odpracovaných hodin nemůže být záporný!");

            return ZakladniPlat * odpracovaneHodiny; // Kč/h × hodiny = celkový plat
        }

        // OVERRIDE ToString()
        public override string ToString()
        {
            string zakladniInfo = base.ToString();
            return $"{zakladniInfo}, pozice: {Pozice}, plat: {VypoctiPlat():C}";
        }
    }
}
