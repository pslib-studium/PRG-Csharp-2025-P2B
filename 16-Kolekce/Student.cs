using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Kolekce
{
    public class Student
    {
        public  string Firstname { get; set; }
        public string Lastname { get; set; }

        public Student(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
