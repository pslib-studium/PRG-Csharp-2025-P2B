// =========================================================
// Základy programování v C# - proměnné, datové typy a cykly
// =========================================================

// -----------------------------------------
// 1. Proměnné a konstanty
// -----------------------------------------
string jmenoStudenta = "Karel";   // camelCase - velbloudí notace pro názvy proměnných
const string JMENO_STUDENTA = "Standa";  // konstanta - hodnota se nemění

jmenoStudenta = "Vašek";                // nové přiřazení proměnné
// JMENO_STUDENTA = "Petr";             // chyba - nelze měnit hodnotu konstanty

// -----------------------------------------
// 2. Datové typy a konverze
// -----------------------------------------
byte maleCislo = 5;    // 'byte' ukládá malé kladné číslo v rozsahu 0-255
maleCislo = 8;         // nové přiřazení hodnoty
// maleCislo = 1000;   // chyba - hodnota je mimo rozsah typu byte

int cislo = maleCislo; // implicitní konverze z menšího typu (byte) na větší (int)
cislo = 11000;

long velkeCislo = 100;
// cislo = velkeCislo;  // chyba - implicitní konverze z long na int není možná
cislo = (int)velkeCislo;  // explicitní konverze (nutné přetypování)

// Pozor - může dojít ke ztrátě informace

double desetinneCislo = 100.5;
cislo = (int)desetinneCislo; // ztrácí se desetinná část 
Console.WriteLine(cislo);    // Výpis: 100

cislo = int.MaxValue;        // maximum hodnoty typu int
Console.WriteLine(cislo);    // Výpis: 2147483647

// -----------------------------------------
// 3. Parsování řetězců na čísla
// -----------------------------------------
string text = "100";
cislo = int.Parse(text);     // převod textu "100" na číslo 100
Console.WriteLine(cislo);    // Výpis: 100

text = "nějaky text";
bool vysledekOperace = int.TryParse(text, out cislo); // pokus o převod na číslo

if (vysledekOperace)
{
    Console.WriteLine(cislo);    // Pokud převod uspěl, vypíše číslo
}
else
{
    Console.WriteLine("Nepodařilo se převést na číslo");  // Pokud selhal 
}

// -----------------------------------------
// 4. Cyklus for
// -----------------------------------------
Console.WriteLine("For cyklus:");
// Cyklus od 1 do 10 s krokem 2 (vypíše lichá čísla)
for (int i = 1; i <= 10; i = i + 2)
{
    Console.WriteLine(i);  // 1, 3, 5, 7, 9
}

// -----------------------------------------
// 5. Cyklus while
// -----------------------------------------
while (cislo > 0)
{
    cislo--;               // sniž číslo o 1
    Console.WriteLine(cislo);  // vypiš aktuální hodnotu
    // cyklus pokračuje, dokud je cislo větší než nula
}

// -----------------------------------------
// 6. Cyklus do-while
// -----------------------------------------
Console.WriteLine("do-while cyklus:");
int j = 1;
do
{
    Console.WriteLine(j);
    j++;                  // zvyš j o 1
} while (j <= 10);        // podmínka kontrolována po provedení bloku

// -----------------------------------------
// 7. Práce s poli a foreach cyklus
// -----------------------------------------
string[] kosik = { "Jablko", "Hruška", "Brambora" };

// foreach projde všechny položky pole a vypíše je
foreach (string polozka in kosik)
{
    Console.WriteLine(polozka);
}

// -----------------------------------------
// 8. Příkaz break 
// -----------------------------------------
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
    {
        break;  // ukončí cyklus, když i dosáhne hodnoty 5
    }
    i++;
    Console.WriteLine(i);    // Výpis: 2, 4
}

// -----------------------------------------
// 9. Použití  continue
// --------------------------------
// Použití continue
for (int k = 0; k < 5; k++)
{
    if (k == 2)
    {
        continue;                                  // Přeskočí 2
    }
    Console.WriteLine("k: " + k);
}
// Výstup: 0,1,3,4