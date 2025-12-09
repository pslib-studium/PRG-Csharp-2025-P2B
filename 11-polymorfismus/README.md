# Polymorfismus v C#

Tento projekt demonstruje pokročilé koncepty objektově orientovaného programování - polymorfismus, virtuální metody, přepis metod a ToString().

## Hierarchie v tomto projektu

```
Osoba (základní třída)
└── Zamestnanec (odvozená třída)
    └── Manager (odvozená třída)
```

### Scénář

Systém pro správu zaměstnanců firmy. Každý typ zaměstnance má jiný způsob výpočtu platu:
- **Zaměstnanec**: základní plat = hodinová sazba × odpracované hodiny
- **Manager**: základní plat + bonus

---

## Osoba - Základní třída

### Struktura třídy

```csharp
public class Osoba
{
    // PRIVATE - přístupný jen uvnitř této třídy
    private string _rodneCislo;
    
    // PROTECTED - přístupný v této třídě a potomcích
    protected int vek;
    
    // PUBLIC - přístupný všude
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    
    // Konstruktor
    public Osoba(string jmeno, string prijmeni, string rodneCislo, int vek) { ... }
    
    // OVERRIDE ToString() - přepsaní metody z object
    public override string ToString()
    {
        return $"{Jmeno} {Prijmeni}";
    }
}
```

**Klíčové vlastnosti:**
- Zapouzdření - rodné číslo je private s validací
- Protected věk - dostupný pro odvozené třídy
- Public vlastnosti pro základní informace
- Statická metoda pro validaci rodného čísla

---

## Zamestnanec - Odvozená třída

### Struktura třídy

```csharp
public class Zamestnanec : Osoba  // Dědí z Osoba
{
    private int _zakladniPlat; // Kč za hodinu
    
    public string Pozice { get; set; }
    public int ZakladniPlat { get; set; } // Hodinová sazba
    
    // Konstruktor - volá base konstruktor
    public Zamestnanec(string jmeno, string prijmeni, string rodneCislo, int vek,
                      string pozice, int zakladniPlat)
        : base(jmeno, prijmeni, rodneCislo, vek)
    {
        Pozice = pozice;
        ZakladniPlat = zakladniPlat; // Hodinová sazba
    }
    
    // VIRTUAL metoda - může být přepsána v odvozených třídách
    public virtual double VypoctiPlat(double odpracovaneHodiny = 40)
    {
        return ZakladniPlat * odpracovaneHodiny; // Kč/h × hodiny
    }
    
    // OVERRIDE ToString()
    public override string ToString()
    {
        string zakladniInfo = base.ToString(); // Volá ToString() z Osoba
        return $"{zakladniInfo}, pozice: {Pozice}, plat: {VypoctiPlat():C}";
    }
}
```

**Klíč:**
- `: base(...)` - volání konstruktoru základní třídy
- `virtual` - metoda může být přepsána v potomcích
- `base.ToString()` - volání metody z Osoba

---

## Manager - Odvozená třída

### Struktura třídy

```csharp
public class Manager : Zamestnanec  // Dědí ze Zamestnanec
{
    private double _bonus;
    
    public double Bonus { get; set; }
    
    // Konstruktor
    public Manager(string jmeno, string prijmeni, string rodneCislo, int vek,
                  double bonus, int odpracovaneHodiny = 40)
        : base(jmeno, prijmeni, rodneCislo, vek, "Manažer", odpracovaneHodiny)
    {
        Bonus = bonus;
    }
    
    // OVERRIDE VypoctiPlat() - přepis virtuální metody
    public override double VypoctiPlat(double odpracovaneHodiny = 40)
    {
        return base.VypoctiPlat(odpracovaneHodiny) + Bonus; // Základní + bonus
    }
}
```

**Klíč:**
- `override` - přepsání virtuální metody ze Zamestnanec
- `base.VypoctiPlat()` - volání původní metody a přidání bonusu
- Manažer má vždy pozici "Manažer"

---

## Virtual a Override

### Virtual metoda

`virtual` klíčové slovo označuje metodu, kterou lze v odvozených třídách přepsat.

```csharp
// V základní třídě Zamestnanec
public virtual double VypoctiPlat(double odpracovaneHodiny = 40)
{
    return ZakladniPlat * odpracovaneHodiny;
}
```

**Proč virtual:**
- Umožňuje odvozeným třídám změnit chování
- Základní implementace poskytuje výchozí logiku
- Polymorfní volání zavolá správnou verzi metody

### Override metoda

`override` klíčové slovo přepíše virtuální metodu v odvozené třídě.

```csharp
// V odvozené třídě Manager
public override double VypoctiPlat(double odpracovaneHodiny = 40)
{
    return base.VypoctiPlat(odpracovaneHodiny) + Bonus;
}
```

**Proč override:**
- Mění chování metody pro daný typ
- `base.` volá původní implementaci
- Zachovává polymorfismus

---

## ToString metoda

### Co je ToString?

`ToString()` je metoda z `object` třídy, kterou dědí všechny třídy v C#. Vrací textovou reprezentaci objektu.

### Příklad z projektu

```csharp
// Osoba
public override string ToString()
{
    return $"{Jmeno} {Prijmeni}";
}

// Zamestnanec
public override string ToString()
{
    string zakladniInfo = base.ToString(); // "Jan Novák"
    return $"{zakladniInfo}, pozice: {Pozice}, plat: {VypoctiPlat():C}";
}
```

**Výstup:**
```
Jan Novák, pozice: Vývojář, plat: 12 000,00 Kč
Eva Novotná, pozice: Manažer, plat: 19 000,00 Kč
```

**Kdy se volá:**
- Implicitně: `Console.WriteLine(zamestnanec);`
- Explicitně: `zamestnanec.ToString()`
- V interpolaci: `$"{zamestnanec}"`

---

## Polymorfní volání

### Princip

Polymorfní volání znamená, že se zavolá správná metoda podle skutečného typu objektu, ne podle typu proměnné.

```csharp
// Všichni jsou typu Zamestnanec (základní typ)
var zamestnanci = new List<Zamestnanec> 
{
    new Zamestnanec("Jan", "Novák", "0000000011", 30, "Vývojář", 300),
    new Manager("Eva", "Novotná", "3300000000", 40, bonus: 5000, odpracovaneHodiny: 350)
};

foreach (var z in zamestnanci)
{
    Console.WriteLine(z); // Volá správnou ToString() podle typu
    Console.WriteLine($"Plat: {z.VypoctiPlat()}"); // Volá správnou VypoctiPlat()
}
```

**Co se stane:**
1. Pro `Zamestnanec`: zavolá se `Zamestnanec.VypoctiPlat()` → `300 × 40 = 12000 Kč`
2. Pro `Manager`: zavolá se `Manager.VypoctiPlat()` → `350 × 40 + 5000 = 19000 Kč`

---

## Modifikátory přístupu

| Modifikátor | V třídě | V odvozené třídě | Mimo třídu |
|-------------|--------|-----------------|-----------|
| `private` | ✅ Ano | ❌ Ne | ❌ Ne |
| `protected` | ✅ Ano | ✅ Ano | ❌ Ne |
| `public` | ✅ Ano | ✅ Ano | ✅ Ano |

### Příklad v projektu:

```csharp
public class Osoba
{
    private string _rodneCislo;  // Jen v Osoba
    protected int vek;           // V Osoba, Zamestnanec, Manager
    public string Jmeno;         // Všude
}

public class Zamestnanec : Osoba
{
    public void NastavVek(int novyVek)
    {
        // ✅ Funguje - protected je dostupný
        vek = novyVek;
        
        // ❌ Nefunguje - private není dostupný
        // _rodneCislo = "...";
    }
}
```

---

## Praktické příklady z projektu

### Příklad 1: Vytvoření zaměstnanců

```csharp
// Běžný zaměstnanec - hodinová sazba 300 Kč/h
var zam1 = new Zamestnanec("Jan", "Novák", "0000000011", 30, "Vývojář", 300);

// Manager - hodinová sazba 350 Kč/h + bonus 5000 Kč
var man = new Manager("Eva", "Novotná", "3300000000", 40, bonus: 5000, odpracovaneHodiny: 350);
```

### Příklad 2: Výpočet platu

```csharp
// Zaměstnanec: 300 Kč/h × 40h = 12 000 Kč
Console.WriteLine($"Plat (40h): {zam1.VypoctiPlat()}");

// Zaměstnanec: 300 Kč/h × 20h = 6 000 Kč
Console.WriteLine($"Plat (20h): {zam1.VypoctiPlat(20)}");

// Manager: 350 Kč/h × 40h + 5000 Kč = 19 000 Kč
Console.WriteLine($"Plat (40h): {man.VypoctiPlat()}");
```

### Příklad 3: ToString výstup

```csharp
Console.WriteLine(zam1);
// Výstup: Jan Novák, pozice: Vývojář, plat: 12 000,00 Kč

Console.WriteLine(man);
// Výstup: Eva Novotná, pozice: Manažer, plat: 19 000,00 Kč
```

### Příklad 4: Polymorfní pole

```csharp
var zamestnanci = new List<Zamestnanec> { zam1, zam2, man };

foreach (var z in zamestnanci)
{
    Console.WriteLine(z); // Polymorfní ToString()
    Console.WriteLine($"Plat (40h): {z.VypoctiPlat()}"); // Polymorfní VypoctiPlat()
    Console.WriteLine($"Plat (20h): {z.VypoctiPlat(20)}");
    Console.WriteLine();
}
```

**Výstup:**
```
Jan Novák, pozice: Vývojář, plat: 12 000,00 Kč
 - mzda (40h): 12000
 - mzda (20h): 6000

Petr Svoboda, pozice: Tester, plat: 8 000,00 Kč
 - mzda (40h): 8000
 - mzda (20h): 4000

Eva Novotná, pozice: Manažer, plat: 19 000,00 Kč
 - mzda (40h): 19000
 - mzda (20h): 12000
```

---

## Validace rodného čísla

Projekt obsahuje statickou metodu pro validaci rodného čísla podle českých pravidel:

```csharp
public static bool OveritRodneCislo(string rc)
{
    if (string.IsNullOrWhiteSpace(rc))
        return false;

    // RČ bez lomítka musí mít 9 nebo 10 číslic
    if (rc.Length != 9 && rc.Length != 10)
        return false;

    // Musí obsahovat jen číslice
    if (!rc.All(char.IsDigit))
        return false;

    // Kontrola dělitelnosti 11
    if (!long.TryParse(rc, out long cislo))
        return false;

    return cislo % 11 == 0;
}
```

**Pravidla:**
- Délka 9 nebo 10 číslic (bez lomítka)
- Pouze číslice
- Dělitelné 11

---

## Porovnání: virtual vs override

| Vlastnost | virtual | override |
|-----------|---------|----------|
| **Kde se používá** | Základní třída | Odvozená třída |
| **Účel** | Označí, co lze přepsat | Přepíše virtuální metodu |
| **Má implementaci** | Ano (výchozí) | Ano (nová verze) |
| **Povinné** | Ne | Ano (pokud chceme přepsat) |
| **base.** | - | Volá původní metodu |

---

## Zapouzdření (Encapsulation)

Projekt demonstruje zapouzdření přes vlastnosti s validací:

```csharp
// Zapouzdření základního platu
public int ZakladniPlat
{
    get { return _zakladniPlat; }
    set
    {
        if (value >= 0)
            _zakladniPlat = value;
        else
            throw new ArgumentException("Plat nemůže být záporný!");
    }
}
```

**Výhody:**
- Validace vstupních hodnot
- Ochrana před neplatnými daty
- Kontrola přístupu k datům

---

## Shrnutí klíčových konceptů

### Polymorfismus:
✅ Různé typy objektů reagují odlišně na stejné volání  
✅ Základní třída definuje `virtual` metody  
✅ Odvozené třídy přepíší metody pomocí `override`  
✅ Polymorfní volání zavolá správnou metodu podle typu

### Virtual a Override:
- `virtual` - základní třída označí, co lze přepsat
- `override` - odvozená třída přepíše metodu
- `base.` - volá metodu ze základní třídy

### ToString():
- Vrací textovou reprezentaci objektu
- Lze přepsat pro vlastní formát
- Volá se implicitně při výpisu

### Zapouzdření:
- Private atributy s public vlastnostmi
- Validace v setterech
- Ochrana dat před neplatnými hodnotami

---

