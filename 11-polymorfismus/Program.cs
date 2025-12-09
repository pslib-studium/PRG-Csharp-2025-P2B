using System;
using System.Collections.Generic;
using _11_polymorfismus;

Console.WriteLine("Ukázka použití tříd Zamestnanec a Manager:");

var zam1 = new Zamestnanec("Jan", "Novák", "0000000011", 30, "Vývojář", 300);
var zam2 = new Zamestnanec("Petr", "Svoboda", "2000000002", 25, "Tester", 200);
var man = new Manager("Eva", "Novotná", "3300000000", 40, bonus: 5000, odpracovaneHodiny: 350);

var zamestnanci = new List<Zamestnanec> { zam1, zam2, man };

foreach (var z in zamestnanci)
{
  
    Console.WriteLine(z);
    Console.WriteLine($" - mzda (40h): {z.VypoctiPlat()}");
    Console.WriteLine($" - mzda (20h): {z.VypoctiPlat(20)}");
    Console.WriteLine();
    
}
