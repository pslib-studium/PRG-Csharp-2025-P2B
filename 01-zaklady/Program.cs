// =========================================================
// Základy programování v C#
// =========================================================

// Tento program demonstruje základní konstrukce jazyka C#,

// -----------------------------------------
// 1. Proměnné 
// -----------------------------------------

int a;              // deklarace proměnné typu int (celé číslo)
a = 10;             // inicializace (první přiřazení)
a = 20;             // nové přiřazení (přepsání hodnoty)

int b = 30;         // deklarace a inicializace v jednom kroku
string c = "Ahoj";  // řetězec (textová data)

/* 
C# je silně typovaný jazyk – typ proměnné je určen při deklaraci
a nedá se změnit.

Například toto by způsobilo chybu:
a = "text";   // proměnná a je typu int -> nelze do něj uložit řetězec
*/


// -----------------------------------------
// 2. Výstup a vstup z konzole
// -----------------------------------------

Console.WriteLine("Napiš nějaký text:"); // výpis na konzoli cw + tab
string text = Console.ReadLine(); // načtení vstupu od uživatele

Console.WriteLine("Opakuji: " + text);

// -----------------------------------------
// 3. Logické výrazy a podmíněné příkazy (if-else)
// -----------------------------------------
int cislo = 10;
bool porovnani = cislo > 10;  // zde bude false, protože 10 není větší než 10

if (cislo > 0)
{
    Console.WriteLine("Číslo je kladné"); // tento blok se vykoná, protože 10 je větší než 0
}


if (text == "ahoj")
{
    Console.WriteLine("Pozdravili jsme se.");
}
else if (text == "čau")
{
    Console.WriteLine("Nazdar!");
}
else
{
    Console.WriteLine("Neznámý pozdrav."); // tento blok se vykoná, pokud předchozí podmínky nebyly splněny
}

// -----------------------------------------
// 4. Příkaz switch
// -----------------------------------------
// Switch umožňuje větvení programu na základě hodnoty proměnné.

cislo = 3;  // přiřadíme nové číslo
switch (cislo)
{
    case 1:
        Console.WriteLine("Číslo je 1");
        break;
    case 2:
        Console.WriteLine("Číslo je 2");
        break;
    case 3:
    case 4:
    case 5:
        // pro více hodnot lze použít společný blok
        Console.WriteLine("Číslo je 3, 4 nebo 5");
        break;
    case 10:
        Console.WriteLine("Číslo je 10");
        break;
    default:
        Console.WriteLine("Číslo není 1, 2 ani 10");
        break;
}