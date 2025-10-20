// =========================================================
// Pole v C# 
// =========================================================

// Deklarace a inicializace pole o velikosti 7 s defaultními hodnotami (nuly)
int[] emptyArr = new int[7];

// Inicializace pole s předdefinovanými hodnotami
int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
string[] fruits = { "Jablko", "Banán", "Pomeranč" };


Console.WriteLine(numbers[0]); // výpis první hodnoty pole (index 0)
Console.WriteLine(numbers[3]); // výpis čtvrté hodnoty pole (index 3)

// Změna hodnoty na indexu 3
numbers[3] = 100;
Console.WriteLine("hodnota změněna na " + numbers[3]);

// Výpis délky pole
Console.WriteLine("Délka pole: " + numbers.Length);

// Výpis hodnot pomocí foreach cyklu
foreach (int num in numbers)
{
    Console.Write(num);
}
// Výpis hodnot pomocí for cyklu
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine($"numbers[{i}] = {numbers[i]}");
}