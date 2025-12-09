using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_polymorfismus
{
    public class Manager : Zamestnanec
    {
        // PRIVATE atribut
        private double _bonus;

        public double Bonus
        {
            get { return _bonus; }
            set
            {
                if (value >= 0)
                    _bonus = value;
            }
        }

        // Konstruktor s výchozí hodnotou 40 hodin
        public Manager(string jmeno, string prijmeni, string rodneCislo, int vek,
                    double bonus, int odpracovaneHodiny = 40)
            : base(jmeno, prijmeni, rodneCislo, vek, "Manažer",
                   odpracovaneHodiny)
        {
            Bonus = bonus;

        }

        // OVERRIDE VypoctiPlat() - přidáme bonus k základnímu platu
        public override double VypoctiPlat(double odpracovaneHodiny = 40)
        {
            return base.VypoctiPlat(odpracovaneHodiny) + Bonus;
        }
    }
}
