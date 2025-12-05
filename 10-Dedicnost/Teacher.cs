using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dedicnost
{
    // Odvozená třída - Teacher dědí od Person (získá FullName, IsAdult)
    public class Teacher : Person
        {
            // Vlastnosti specifické pro učitele - tituly před a za jménem
            public string? TitleBefore { get; set; } // Příklad: "Mgr.", "Doc."
            public string? TitleAfter { get; set; }   // Příklad: "PhD.", "CSc."

            // Konstruktor: tituly jsou nepovinné (default null)           
            public Teacher(string firstName, string lastName, int age, 
            string? titleBefore = null, string? titleAfter = null) : base(firstName, lastName, age)
        {
            TitleBefore = titleBefore;
            TitleAfter = titleAfter;
        }

        // Metoda: vrací jméno s tituly (?? operátor = pokud je null, použij "")
        // Příklady: "Mgr. Karel Novotný", "Marie Svobodová PhD.", "Jan Svoboda"
        public string Info() 
        {
            return $"{this.TitleBefore ?? ""}{base.FullName}{this.TitleAfter ?? ""}"; 
        }
    }
}
