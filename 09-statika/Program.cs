using _09_statika;

// Použití statické třídy Numerics - BEZ new!
Console.WriteLine($"Sčítání: {Numerics.Addition(10, 5)}");           
Console.WriteLine($"Odečítání: {Numerics.Subtraction(20, 8)}");      
     
// Kombinace metod - složitější výpočet
int obvod = Numerics.Multiplication(2, Numerics.Addition(5, 12));

// Vytvoření dvou instancí Student
Student pepa = new Student(15, "Pepa");
Student karel = new Student(16);

// Výpis informací 
pepa.PrintInfo();

karel.Name = "Karel";
karel.PrintInfo();

karel.Age = 17;
Console.WriteLine("\n=== Karelovi změněn věk na 17 ===");
pepa.PrintInfo();  // Pepa, 15 let... (Pepův věk NEZMĚNĚN!)
karel.PrintInfo(); // Anonym, 17 let... (jen Karelův věk změněn)

// Změna názvu školy statickou vlastností přímo přes třídu
Student.schoolName = "Škola bez jména";

// Výpis informací po změně názvu školy - u obou studentů se změna projeví
pepa.PrintInfo();
karel.PrintInfo();

// Změna názvu školy přes instanční metodu Karla (opět se změní všem)
karel.changeSchoolName("Něco jiného");

pepa.PrintInfo();

// Volání statické metody pro výpis názvu školy
Student.PrintSchool();

