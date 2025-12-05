using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dedicnost
{
    // Základní třída - slouží jako základ pro Student a Teacher (dědičnost)
    public class Person
        {
            // Protected - dostupné v odvozených třídách (Student, Teacher)
            protected string _firstName;
            protected string _lastName;

            private int _age; // Private - přístup pouze v téže třídě       

        public Person(string firstName, string lastName, int age )
        {
            _firstName = firstName;
            _lastName = lastName;

            if (age <= 0) {
                throw new ArgumentException("Věk musí být větší než 0");
            }
            
            _age = age;                   
        
        }

        // Vlastnost: vrací true pokud je osoba plnoletá (věk >= 18)       
        public bool IsAdult { 
        
        get { return _age >= 18; }

        }

        // Vlastnost: vrací plné jméno (křestní jméno + příjmení)
        // Příklad: person.FullName vrací "Jan Novák"
        public string FullName { 
        
            get { return $"{ _firstName } { this._lastName}"; }
        }

    }
}
