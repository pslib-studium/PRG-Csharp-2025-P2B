using System.Diagnostics; //Třída Stopwatch je v System.Diagnostic

// Získání aktuálního času
DateTime now = DateTime.Now;
DateTime utcNow = DateTime.UtcNow;
Console.WriteLine($"Aktuální čas: {now}");
Console.WriteLine($"UTC čas: {utcNow}");

// Vytvoření specifického data
DateTime specificDate = new DateTime(2022, 5, 1, 8, 30, 52);
Console.WriteLine($"Specifické datum: {specificDate}");

// Získání jednotlivých částí data
Console.WriteLine($"Rok: {now.Year}, Měsíc: {now.Month}, Den: {now.Day}");
Console.WriteLine($"Hodina: {now.Hour}, Minuta: {now.Minute}, Sekunda: {now.Second}");
Console.WriteLine($"Den v týdnu: {now.DayOfWeek}");

// Změna datumu pomocí metod
DateTime futureDate = now.AddDays(5).AddHours(3);
Console.WriteLine($"Za 5 dní a 3 hodiny: {futureDate}");

// Vstup hodnot
Console.Write("Zadejte datum a čas ve formátu dd.MM.yyyy HH:mm:ss: ");
DateTime userDate = DateTime.Parse(Console.ReadLine());
Console.WriteLine($"Zadané datum a čas: {userDate}");

// Použití TimeSpan
TimeSpan duration = TimeSpan.FromMinutes(30);
Console.WriteLine($"Celkový čas v minutách: {duration.TotalMinutes}, Hodiny: {duration.Hours}");

// Porovnání dvou dat pomocí TimeSpan
TimeSpan difference = futureDate - now;
Console.WriteLine($"Rozdíl mezi daty: {difference.TotalHours} hodin");

// Měření času pomocí Stopwatch
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
await Task.Delay(1000); // Simulace činnosti
stopwatch.Stop();
Console.WriteLine($"Čas uplynulý na stopkách: {stopwatch.Elapsed}");
Console.WriteLine($"Počet taktů: {stopwatch.ElapsedTicks}");

// Alternativní měření času bez instance Stopwatch
long startTime = Stopwatch.GetTimestamp();
await Task.Delay(1000);
long endTime = Stopwatch.GetTimestamp();
TimeSpan elapsed = Stopwatch.GetElapsedTime(startTime, endTime);
Console.WriteLine($"Uplynulý čas mezi startem a koncem: {elapsed}");