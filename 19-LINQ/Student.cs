using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_LINQ
{
    public class Student
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        public string Trida { get; set; }

        public string Bydliste { get; set; }

        public override string ToString()
        {
            return this.Jmeno + " " + this.Prijmeni + "(" + this.Trida + " | " + this.Bydliste + ")";
        }


    }
}
