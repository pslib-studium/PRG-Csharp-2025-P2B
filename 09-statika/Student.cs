using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_statika
{
    internal class Student
    {
        // Statické pole sdílené všemi instancemi třídy
        public static string schoolName = "Skvělá škola";

        // Automatická vlastnost jména s volným přístupem pro čtení/zápis
        public string Name { get; set; } = "Anonym";

        // Vlastnost věku - čitelná i zapisovatelná zvenčí třídy
        public int Age { get; set; }

        // Konstruktor s jedním parametrem - nastaví pouze věk
        public Student(int age)
        {
            this.Age = age;
        }

        // Přetížený konstruktor - nastaví jméno i věk
        public Student(int age, string name)
        {
            this.Name = name;
            this.Age = age;
        }

        // Veřejná metoda pro výpis informací o studentovi
        public void PrintInfo()
        {
            Console.WriteLine(this.Info());
        }

        // Privátní metoda 
        private string Info()
        {
            return $"{Name}, {Age} let, {schoolName}";
        }



        // Statická metoda – NEPRACUJE s instancí
        public static void PrintSchool()
        {
            Console.WriteLine($"Všichni studenti chodí do školy: {schoolName}");
        }

        // Metoda pro změnu názvu školy (ovlivní všechny studenty protože schoolName je statický)
        public void changeSchoolName(string newName)
        {
            schoolName = newName;
        }

    }

}

