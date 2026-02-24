// Delegáty v C# - přehledná výuková ukázka

// 1) Vstupní hodnoty, se kterými budeme počítat.
double prvniCislo = 4;
double druheCislo = 5;

// 2) VLASTNÍ DELEGÁT
// Delegát je "proměnná pro metodu" - může ukazovat na různé metody se stejnou signaturou.
MathOp matematickaOperace = Secti;
double soucet = matematickaOperace(prvniCislo, druheCislo);

matematickaOperace = Vynasob;
double soucin = matematickaOperace(prvniCislo, druheCislo);

Console.WriteLine("Vlastní delegát (přepnutí metody):");
Console.WriteLine($"Součet: {soucet}, Součin: {soucin}");

// 3) DELEGÁT JAKO PARAMETR METODY
// Stejná metoda Vypocitej výsledek vypočítá podle toho, jakou operaci jí předáme.
double vysledekMetoda = Vypocitej(prvniCislo, druheCislo, Secti);
double vysledekLambda = Vypocitej(prvniCislo, druheCislo, (x, y) => x - y);

Console.WriteLine("Delegát předaný do metody:");
Console.WriteLine($"Metoda Secti: {vysledekMetoda}, Lambda odčítání: {vysledekLambda}");

// 4) PŘEDDEFINOVANÝ DELEGÁT FUNC
// Func<T1, T2, TResult> = 2 vstupy + návratová hodnota.
Func<double, double, double> deleni = (x, y) => x / y;
double podil; 

podil = PouzijFunc(prvniCislo, druheCislo, deleni);
podil = PouzijFunc(prvniCislo, druheCislo, (x, y) => x / y); // můžeme použít i přímo lambda výraz bez proměnné delegátu

Console.WriteLine("Func delegát:");
Console.WriteLine($"Podíl: {podil}");

// ----- Metody použité v ukázce -----

double Secti(double x, double y) => x + y;
double Vynasob(double x, double y) => x * y;

double Vypocitej(double x, double y, MathOp operace)
{
    return operace(x, y);
}

double PouzijFunc(double x, double y, Func<double, double, double> operace)
{
    return operace(x, y);
}

// Definice vlastního delegátu: přijme 2 čísla a vrátí číslo.
delegate double MathOp(double x, double y);
