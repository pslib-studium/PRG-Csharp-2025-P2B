// -------------------- Nullable pole --------------------
int[] pole = new int[5];
pole = null; // pole je nyní null,  neukazuje na žádná data v paměti.
// Nelze vytvořit pole typu int[] s hodnotou null uvnitř protože běžný typ int nemůže obsahovat null hodnotu.


// Použití typu int?, který umožňuje ukládat null hodnoty.
int?[] poleSNull = { 5, 10, null }; // zde již pole může obsahovat null

// int c = null; // nelze 
// Základní typ int nemůže obsahovat null, došlo by ke kompilátorové chybě.

// Používáme tzv. nullable value type int?
int? c = null; // int? může být null

// Pomocí vlastnosti HasValue můžeme zjistit, zda má proměnná c nastavenou hodnotu, nebo je null.
Console.WriteLine(c.HasValue); // vypíše 'false', pokud je null


foreach (int? prvek in poleSNull)
{
 
    if (prvek.HasValue)
    {
        // Pokud má prvek hodnotu, vypíše ji na konzoli.
        Console.WriteLine(prvek); 
    }
}

// -------------------- Příklad 1: ošetření vyjimky --------------------

// Příklad práce s dělením nulou a ošetřením výjimky

int a = 10;
int b = 0;

try
{
    // Pokusíme se dělit nulou – vznikne zde výjimka
    int vysledek = a / b;
}
catch (DivideByZeroException ex)
{
    // Zpracování výjimky 
    Console.WriteLine("Chyba: Nelze dělit nulou.");
    // Výpis detailu výjimky (popis chyby)
    Console.WriteLine($"Detail chyby: {ex.Message}");
}

// -------------------- Příklad 2: vyhození vyjimky --------------------
void printValAtIndex(int[] pole, int index)
{
    // Ověření, zda je pole null
    if (pole == null)
    {
        throw new ArgumentNullException("Pole nesmí být null.");
    }
    // Ověření, zda je index záporný
    if (index < 0)
    {
        throw new ArgumentOutOfRangeException("index", "Chyba: Index nemůže být záporný.");
    }
    // Ověření, zda index není mimo rozsah pole
    if (index >= pole.Length)
    {
        throw new IndexOutOfRangeException("Chyba: Index je mimo rozsah pole.");
    }
    // Pokud jsou všechny kontroly v pořádku, vypíše hodnotu na daném indexu
    Console.WriteLine($"Hodnota na indexu {index}: {pole[index]}");
}


int[] cisla = { 10, 20, 30, 40, 50 };
try
{
    // Zavoláme funkci s neplatným (záporným) indexem, což způsobí vyhození výjimky
    printValAtIndex(cisla, -1);  
    Console.WriteLine("Tento řádek se nemusí provést, pokud dojde k výjimce výše");

}
catch (ArgumentOutOfRangeException ex)
{
    // Zpracování konkrétní výjimky - index byl záporný
    Console.WriteLine($"ArgumentOutOfRangeException: {ex.Message}");
}
catch (Exception ex)
{
    // Zpracování obecné výjimky 
    Console.WriteLine(ex.Message);
}
finally
{   
    Console.WriteLine(" Tento blok se provede vždy, ať už došlo k výjimce, nebo ne");
}