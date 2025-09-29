// ===========================================================
// Podprogramy (metody, funkce) v C# - přehled & příklady
// ===========================================================

/*
STRUČNÁ SYNTAXE METODY:
[modifikátory] návratový_typ NázevMetody([parametry])
{
    // Tělo metody
    return [hodnota]; // pouze pokud návratový_typ není void
}

Popis částí:
  1) (volitelně) modifikátor (private, public, protected, static, virtual, abstract, override...)
  2) návaratoý typ string, int ... void -> prázdný návratový typ - funkce nic nevrací 
  3) Název metody/funkce/podprogramu
  4) (volitelné) parametry funkce (datovy typ + název parametru) např. (int a, string text ...)
  5) { tělo funkce, klíčové slovo return pro návrat s hodnotou }


*/

// -------------------------------------------------------------------------
// 1. Bezparametrická metoda (pozdrav)
// -------------------------------------------------------------------------

/// <summary>
/// Vypíše jednoduchý pozdrav do konzole.
/// Nemá žádné parametry ani návratovou hodnotu.
/// </summary>
static void Print()
{
    Console.WriteLine("Ahoj, světe!");
}

// -------------------------------------------------------------------------
// 2. Metoda s parametry a návratovou hodnotou
// -------------------------------------------------------------------------

/// <summary>
/// Sečte dvě čísla a vrátí jejich součet.
/// </summary>
static int Addition(int a, int b)
{
    return a + b; // Vrací součet parametrů a a b
}

// -------------------------------------------------------------------------
// 3. Metoda s implicitním (defaultním) parametrem
// -------------------------------------------------------------------------

/// <summary>
/// Zvýší dané číslo o hodnotu parametru (nebyl-li zadán, zvýší o 1)
/// </summary>
static int Increase(int value, int increment = 1)
{
    return value + increment; // Pokud není increment zadán, použije se 1
}

// -------------------------------------------------------------------------
// 4. Metoda s podmíněným ukončením (return)
// -------------------------------------------------------------------------

/// <summary>
/// Ověří, zda číslo je záporné.
/// Vypíše text a ukončí metodu při záporné hodnotě.
/// </summary>
static void CheckValue(int num)
{
    if (num < 0)
    {
        Console.WriteLine("Číslo je záporné.");
        return; // Ukončí metodu pro záporná čísla
    }
    // další kód
    Console.WriteLine("Číslo je kladné nebo nula.");
}

// -------------------------------------------------------------------------
// 5. Metoda s modifikátorem ref (změna proměnné) 
// -------------------------------------------------------------------------

/// <summary>
/// Zvýší zadanou proměnnou o 1 – proměnná se mění i mimo metodu.
/// </summary>
static void Increment(ref int value)
{
    value += 1;
}

// -------------------------------------------------------------------------
// 6. Metoda vracející více hodnot (out parametry)
// -------------------------------------------------------------------------

/// <summary>
/// Rozdělí dvouciferné číslo do hodnot desítek a jednotek (pomocí out).
/// </summary>
static void SplitNumber(int number, out int tens, out int units)
{
    tens = number / 10;     // vypočítá desítky
    units = number % 10;    // vypočítá jednotky
}

// -------------------------------------------------------------------------
// PŘÍKLADY POUŽITÍ METOD
// -------------------------------------------------------------------------

// Volání metody bez parametrů
Print();

// Volání metody se dvěma parametry, výsledek uložím do result
int result = Addition(3, 5);
Console.WriteLine("Součet: " + result);

// Volání metody s default parametrem
int newValue = Increase(10);     // použije increment = 1, výsledek 11
int newValue2 = Increase(10, 5); // použije increment = 5, výsledek 15

// Ukázka použití metody ukončené return
CheckValue(-5);  // Výpis: "Číslo je záporné."
CheckValue(7);   // Výpis: "Číslo je kladné nebo nula."

// Ukázka metody s ref - změní hodnotu proměnné counter
int counter = 0;
Increment(ref counter);
Console.WriteLine("Hodnota čítače: " + counter); // Výpis: 1

// Ukázka metody s out - rozdělení čísla na desítky a jednotky
int number = 42;
int tens, units;
SplitNumber(number, out tens, out units);
Console.WriteLine($"Číslo: {number}, desítky: {tens}, jednotky: {units}"); // Výpis: 4, 2

// -------------------------------------------------------------------------
// 7. Srovnání předání parametru hodnotou vs referencí
// -------------------------------------------------------------------------

/// Předání hodnotou – originální proměnná se nemění
int AddAndChange(int x, int y)
{
    x = 20; // mění jen lokální kopii
    return x + y;
}

int a = 10, b = 10;
AddAndChange(a, b); // 30
Console.WriteLine("hodnota a: " + a); // Stále 10, nezměněno!

/// Předání odkazem (ref) – změní i původní proměnnou!
int AddAndChangeRef(ref int x, ref int y)
{
    x = 20; // změní i původní proměnnou
    return x + y;
}

AddAndChangeRef(ref a, ref b); // Výsledek: 30
Console.WriteLine("hodnota a: " + a); // Už je 20!

// -------------------------------------------------------------------------
// VYSVĚTLIVKY K POUŽITÝM KONSTRUKCÍM
// -------------------------------------------------------------------------
/*
- void: metoda nic nevrací (neobsahuje příkaz return s hodnotou).
- ref: předává hodnotu “odkazem” – změny v metodě se projeví i v původní proměnné.
- out: umožní vrátit více hodnot (proměnné se “vrátí” ven z metody).
- return: předá výsledek/ukončí metodu.
- defaultní parametr: zadá výchozí hodnotu, pokud není při volání uvedena.
- CamelCase: běžný zápis názvů metod a tříd v C# (např. PrintUserData).
*/
