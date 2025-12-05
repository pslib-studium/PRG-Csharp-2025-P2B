using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dedicnost
{
    // Odvozená třída - Student dědí od Person (získá FullName, IsAdult)
    public class Student : Person
    {
        // Vlastnost specifická pro studenta - třída, kam chodí
        public string ClassName { get; set; }
        
        // Vlastnost pro pohlaví (M = muž, Ž = žena)
        public char Gender { get; set; }
        
        // Konstruktor: volá konstruktor základní třídy přes base(...)
      
        public Student(string firstName, string lastName, int age, string className, char gender = 'M')
                : base(firstName, lastName, age)
        {
            ClassName = className;
            Gender = gender;
        }


        // Metoda: vrací text popisující studenta (kombinuje data ze Student a Person)
        // Příklad: alice.Info() vrací "Nováková chodí do E3C a není plnoletá"
        public string Info()
        {
            string status;
            
            if (Gender == 'Ž')
            {
                status = base.IsAdult ? "je plnoletá" : "není plnoletá";
            }
            else
            {
                status = base.IsAdult ? "je plnoletý" : "není plnoletý";
            }
            
            return $"{base._lastName} chodí do {ClassName} a {status}";
        }
    }

}
