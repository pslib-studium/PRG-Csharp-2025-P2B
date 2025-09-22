// =========================================================
// Operátory
// =========================================================

int i = 0;
i = i + 1; // 1
i++; // 2
i += 1; // 3 
++i; // 4 
Console.WriteLine(i);


int a = 2;
int b = 3;

// Před-dekrementace
int c = --a + b;   // Nejprve se odečte 1 od a, pak se sečte s b (1 + 3 = 4)
Console.WriteLine(c); //  4

a = 2;
b = 3;

// Post-dekrementace
int d = a-- + b;   // Nejprve se použije původní a (2 + 3 = 5), teprve potom se a zmenší o 1 (2 - 1 = 1)
Console.WriteLine(d); //  5


int mod = 5 % 4; // modulo -> zbytek po dělení, výsledek je 1 


// ( a + b) + c = a + (b +c) asociativita
//  a * b = b * a Komutativita 


// Priorita vyhodnocování 
c = 4 * 8 / 2 + 7 / (4 % 5);

// 1) Závorky: (4 % 5) = 4
// 2) Násobení a dělení: (4*8)/2 = 32/2 = 16; 7/4 = 1
// 3) Sčítání: 16 + 1 = 17
Console.WriteLine(c); // = 17


// Bitové operace
d = 5 | 3; // Bitový OR alt + W -> |

// 101
// 011
// ----
// 111 -> 7
Console.WriteLine(d);


c = a & b; // AND
c = a ^ b; // XOR alt + š 
c = ~a; // bitová negace alt + 1

// boolovské operátory
bool f = false; // true/false
bool g = !f; // negace (true)
f = g && true; // logický AND
f = g || true; // logický OR
// rovná se ==
a = 1;
b = 3;

bool e = (a == 1 && b == 2) || (a == 2 && b == 3); // false

if (e)
{
    Console.WriteLine("výsledek operace je true");
}
else
{
    Console.WriteLine("výsledek false");
}

// ternální operátor 
// podminka ? vyrazPokudPravda : vyrazPokudNepravda
int j = 6;
string vysledek = (j > 0) ? "Kladné číslo" : "Záporné nebo nula";

a = j == 5 ? 1 : 2; // 2

Console.WriteLine(vysledek);


// Výchozí hodnoty proměnných
int m = default;      // 0
int? n = default;     // null
bool hh = default;    // false
Console.WriteLine(hh); 