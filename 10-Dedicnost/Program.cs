using dedicnost;

// Příklad 1: Vytvoření studentky - Student dědí od Person
Student alice = new Student("Alice", "Nováková", 17, "E3C", 'Ž');
Console.WriteLine($"Jméno: {alice.FullName}");     // Zděděná vlastnost
Console.WriteLine($"Info: {alice.Info()}");        // Vlastní metoda

// Příklad 2: Vytvoření učitele s titálem - Teacher dědí od Person
Teacher novotny = new Teacher("Karel", "Novotný", 58, "Mgr.");
Console.WriteLine($"Učitel: {novotny.Info()}");    // Kombinuje titul + jméno

// Příklad 3: Polymorfní pole - obsahuje různé typy osob (všichni jsou Person)
Person[] people = {
    new Student("Alice", "Nováková", 17, "E3C", 'Ž'),
    new Teacher("Karel", "Novotný", 58, "Mgr."),
    new Student("Petr", "Dvořák", 15, "P1A"),
    new Student("Aleš", "Malý", 16, "S2B"),
    new Person("Tomáš", "Nesvačil", 44)
};

// Příklad 4: Iterace přes pole - všichni mají FullName (zděděno od Person)
Console.WriteLine("\nVšechny osoby:");
foreach (Person person in people) {
    Console.WriteLine($"  - {person.FullName} (plnoletý: {person.IsAdult})");
}

