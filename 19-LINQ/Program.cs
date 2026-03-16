using _19_LINQ;

List<Student> studenti = VytvorListStudentu();

// 1. Zkopírování celé kolekce do nového seznamu.
List<Student> vsichniStudenti = studenti.ToList();

// 2. Výběr studentů, kteří bydlí v Liberci.
List<Student> studentiZLiberce = studenti
    .Where(x => x.Bydliste == "Liberec")
    .ToList();

Console.WriteLine("Studenti z Liberce:");
foreach (Student student in studentiZLiberce)
{
    Console.WriteLine(student);
}

Console.WriteLine();

// 3. Seřazení studentů podle příjmení.
List<Student> serazeniPodlePrijmeni = studenti
    .OrderBy(x => x.Prijmeni)
    .ToList();

// 4. Seřazení sestupně podle příjmení,
//    při shodě rozhoduje jméno vzestupně.
List<Student> serazeniSestupne = studenti
    .OrderByDescending(student => student.Prijmeni)
    .ThenBy(student => student.Jmeno)
    .ToList();

// 5. Prvních 5 studentů podle abecedy.
List<Student> prvnichPetStudentu = studenti
    .OrderBy(student => student.Prijmeni)
    .Take(5)
    .ToList();

// 6. Přehled tříd a počtu studentů v jednotlivých třídách.
Console.WriteLine("Počet studentů v jednotlivých třídách:");
foreach (var skupina in studenti.GroupBy(student => student.Trida))
{
    Console.WriteLine($"{skupina.Key}: {skupina.Count()}");
}

// Pomocná metoda vrací připravená testovací data
static List<Student> VytvorListStudentu()
{
    return new List<Student>
    {
        new Student { Jmeno = "Jan", Prijmeni = "Novak", Bydliste = "Liberec", Trida = "P2A" },
        new Student { Jmeno = "Petr", Prijmeni = "Svoboda", Bydliste = "Jablonec", Trida = "P2A" },
        new Student { Jmeno = "Lukas", Prijmeni = "Dvorak", Bydliste = "Turnov", Trida = "P2A" },
        new Student { Jmeno = "Martin", Prijmeni = "Dvorak", Bydliste = "Liberec", Trida = "P2A" },
        new Student { Jmeno = "Tomas", Prijmeni = "Prochazka", Bydliste = "Frydlant", Trida = "P2A" },
        new Student { Jmeno = "Ondrej", Prijmeni = "Kucera", Bydliste = "Liberec", Trida = "P2A" },
        new Student { Jmeno = "David", Prijmeni = "Vesely", Bydliste = "Turnov", Trida = "P2A" },
        new Student { Jmeno = "Michal", Prijmeni = "Horak", Bydliste = "Jablonec", Trida = "P2A" },
        new Student { Jmeno = "Filip", Prijmeni = "Nemec", Bydliste = "Liberec", Trida = "P2A" },
        new Student { Jmeno = "Adam", Prijmeni = "Marek", Bydliste = "Ceska Lipa", Trida = "P2A" },

        new Student { Jmeno = "Jakub", Prijmeni = "Pokorny", Bydliste = "Liberec", Trida = "P2B" },
        new Student { Jmeno = "Daniel", Prijmeni = "Pospisil", Bydliste = "Turnov", Trida = "P2B" },
        new Student { Jmeno = "Matej", Prijmeni = "Hajek", Bydliste = "Liberec", Trida = "P2B" },
        new Student { Jmeno = "Dominik", Prijmeni = "Kratochvil", Bydliste = "Jablonec", Trida = "P2B" },
        new Student { Jmeno = "Patrik", Prijmeni = "Jelinek", Bydliste = "Frydlant", Trida = "P2B" },
        new Student { Jmeno = "Radek", Prijmeni = "Zeman", Bydliste = "Liberec", Trida = "P2B" },
        new Student { Jmeno = "Roman", Prijmeni = "Kolar", Bydliste = "Ceska Lipa", Trida = "P2B" },
        new Student { Jmeno = "Ales", Prijmeni = "Navratil", Bydliste = "Turnov", Trida = "P2B" },
        new Student { Jmeno = "Vojtech", Prijmeni = "Urban", Bydliste = "Liberec", Trida = "P2B" },
        new Student { Jmeno = "Stepan", Prijmeni = "Blaha", Bydliste = "Jablonec", Trida = "P2B" },

        new Student { Jmeno = "Eva", Prijmeni = "Kralova", Bydliste = "Liberec", Trida = "P2C" },
        new Student { Jmeno = "Anna", Prijmeni = "Benesova", Bydliste = "Turnov", Trida = "P2C" },
        new Student { Jmeno = "Tereza", Prijmeni = "Fialova", Bydliste = "Jablonec", Trida = "P2C" },
        new Student { Jmeno = "Lucie", Prijmeni = "Sedlakova", Bydliste = "Liberec", Trida = "P2C" },
        new Student { Jmeno = "Klara", Prijmeni = "Sykorova", Bydliste = "Ceska Lipa", Trida = "P2C" },
        new Student { Jmeno = "Veronika", Prijmeni = "Dolezalova", Bydliste = "Frydlant", Trida = "P2C" },
        new Student { Jmeno = "Nikola", Prijmeni = "Ticha", Bydliste = "Liberec", Trida = "P2C" },
        new Student { Jmeno = "Barbora", Prijmeni = "Polakova", Bydliste = "Turnov", Trida = "P2C" },
        new Student { Jmeno = "Adela", Prijmeni = "Vackova", Bydliste = "Jablonec", Trida = "P2C" },
        new Student { Jmeno = "Karolina", Prijmeni = "Bartosova", Bydliste = "Liberec", Trida = "P2C" },

        new Student { Jmeno = "Natalie", Prijmeni = "Krejci", Bydliste = "Liberec", Trida = "P3A" },
        new Student { Jmeno = "Eliska", Prijmeni = "Hudcova", Bydliste = "Turnov", Trida = "P3A" },
        new Student { Jmeno = "Sara", Prijmeni = "Moravcova", Bydliste = "Jablonec", Trida = "P3A" },
        new Student { Jmeno = "Kristyna", Prijmeni = "Andrlova", Bydliste = "Liberec", Trida = "P3A" },
        new Student { Jmeno = "Denisa", Prijmeni = "Bilkova", Bydliste = "Ceska Lipa", Trida = "P3A" },
        new Student { Jmeno = "Petra", Prijmeni = "Krizova", Bydliste = "Frydlant", Trida = "P3A" },
        new Student { Jmeno = "Lenka", Prijmeni = "Malikova", Bydliste = "Liberec", Trida = "P3A" },
        new Student { Jmeno = "Ivana", Prijmeni = "Vondrackova", Bydliste = "Turnov", Trida = "P3A" }
    };
}
