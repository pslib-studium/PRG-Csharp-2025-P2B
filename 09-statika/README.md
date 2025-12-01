# Statika v C#

Tento projekt demonstruje použití statických prvků v C# a jejich rozdíl oproti instančním prvkům.

## Co je statika?

**Statické prvky** patří celé třídě, ne konkrétní instanci (objektu). Existují pouze v jedné kopii sdílené všemi instancemi třídy.

**Instanční prvky** patří konkrétní instanci objektu. Každý objekt má své vlastní kopie těchto prvků.

---

## Statická třída

### Co je statická třída?

Statická třída je třída označená klíčovým slovem `static`. Nemůže být vytvořena instance této třídy (nelze použít `new`).

### Vlastnosti statické třídy:
- **Nelze vytvořit instanci** - nelze použít operátor `new`
- **Všechny členy musí být statické** - nemůže obsahovat instanční metody nebo atributy
- **Nemůže mít konstruktor** - není třeba, protože se nevytváří instance
- **Nemůže dědit** - ani být zděděna

### Příklad ze `Numerics.cs`:

```csharp
public static class Numerics
{
    public static int Addition(int a, int b)
    {
        return a + b;
    }

    public static int Subtraction(int a, int b)
    {
        return a - b;
    }
}
```

### Jak se volá:

```csharp
// Volání statické metody ze statické třídy
int result = Numerics.Addition(10, 5);  // Voláme přes název třídy!

// NELZE vytvořit instanci:
// Numerics calc = new Numerics();  ❌ CHYBA!
```

### Kdy použít statickou třídu:
- Pro pomocné metody (matematické operace, konverze, utility)
- Když nepotřebujete ukládat stav
- Příklady: `Math`, `Console`, `Convert`

---

## Statický atribut (pole, vlastnost)

### Co je statický atribut?

Atribut označený klíčovým slovem `static` je sdílen všemi instancemi třídy. Existuje pouze v jedné kopii v paměti.

### Vlastnosti statického atributu:
- **Sdílený všemi instancemi** - změna se projeví u všech objektů
- **Přístup přes název třídy** - obvykle se používá `TridaNazev.atribut`
- **Existuje i bez instance** - není třeba vytvářet objekt

### Příklad ze `Student.cs`:

```csharp
internal class Student
{
    // Statický atribut - sdílený všemi studenty
    public static string schoolName = "Skvělá škola";
    
    // Instanční atribut - každý student má své vlastní
    public string Name { get; set; } = "Anonym";
    public int Age { get; set; }
}
```

### Jak se volá:

```csharp
// Přístup ke statickému atributu přes název třídy
Console.WriteLine(Student.schoolName);  // "Skvělá škola"

// Změna statického atributu - ovlivní VŠECHNY studenty
Student.schoolName = "Nová škola";

// Vytvoření instancí
Student pepa = new Student(15, "Pepa");
Student karel = new Student(16, "Karel");

// Přístup k instančním atributům - každý má své vlastní
Console.WriteLine(pepa.Name);  // "Pepa"
Console.WriteLine(karel.Name); // "Karel"

// Obě instance vidí stejnou školu (statický atribut)
pepa.PrintInfo();  // Pepa, 15 let, Nová škola
karel.PrintInfo(); // Karel, 16 let, Nová škola
```

### Porovnání:

| Vlastnost | Statický atribut | Instanční atribut |
|-----------|------------------|-------------------|
| **Počet kopií** | 1 pro celou třídu | 1 pro každou instanci |
| **Přístup** | `TridaNazev.atribut` | `instance.atribut` |
| **Sdílení** | Sdílený všemi instancemi | Každá instance má svůj |
| **Změna** | Ovlivní všechny instance | Ovlivní jen danou instanci |

---

## Statická metoda

### Co je statická metoda?

Metoda označená klíčovým slovem `static` patří celé třídě, ne konkrétní instanci.

### Vlastnosti statické metody:
- **Volá se přes název třídy** - není třeba vytvářet instanci
- **Nemá přístup k instančním členům** - nemůže používat `this`
- **Může pracovat jen se statickými členy** - nebo s parametry
- **Existuje i bez instance třídy**

### Příklad ze `Student.cs`:

```csharp
internal class Student
{
    public static string schoolName = "Skvělá škola";
    public string Name { get; set; }
    
    // Statická metoda - NEPRACUJE s instancí
    public static void PrintSchool()
    {
        Console.WriteLine($"Všichni studenti chodí do školy: {schoolName}");
        // Console.WriteLine(this.Name);  ❌ CHYBA! Nemůže použít 'this'
    }
    
    // Instanční metoda - pracuje s konkrétní instancí
    public void PrintInfo()
    {
        Console.WriteLine($"{Name}, {Age} let, {schoolName}");
        // Může používat jak instanční (Name, Age), tak statické (schoolName) členy
    }
}
```

### Jak se volá:

```csharp
// Volání statické metody - přes název třídy
Student.PrintSchool();  // Nepotřebujeme instanci!

// Volání instanční metody - přes objekt
Student pepa = new Student(15, "Pepa");
pepa.PrintInfo();  // Potřebujeme konkrétní instanci
```

### Porovnání:

| Vlastnost | Statická metoda | Instanční metoda |
|-----------|-----------------|------------------|
| **Volání** | `TridaNazev.Metoda()` | `instance.Metoda()` |
| **Potřebuje instanci** | Ne | Ano |
| **Přístup k instančním členům** | Ne (nemá `this`) | Ano (má `this`) |
| **Přístup ke statickým členům** | Ano | Ano |
| **Kdy použít** | Utility, pomocné funkce | Práce se stavem objektu |

---

## Shrnutí rozdílů

### Statické prvky:
✅ Patří celé třídě  
✅ Sdílené všemi instancemi  
✅ Volají se přes název třídy  
✅ Existují i bez vytvoření instance  
✅ V paměti pouze 1 kopie  
❌ Nemohou používat `this`  
❌ Nemají přístup k instančním členům  

### Instanční prvky:
✅ Patří konkrétní instanci  
✅ Každá instance má své vlastní  
✅ Volají se přes instanci (objekt)  
✅ Mohou používat `this`  
✅ Mají přístup k instančním i statickým členům  
❌ Vyžadují vytvoření instance (`new`)  
❌ Každá instance zabírá paměť  

---

## Praktické příklady z projektu

### 1. Statická třída Numerics
```csharp
// Matematické operace - nepotřebují stav
int sum = Numerics.Addition(10, 5);
int product = Numerics.Multiplication(3, 4);
```

### 2. Statický atribut školního názvu
```csharp
// Všichni studenti chodí do stejné školy
Student.schoolName = "Gymnázium";

Student pepa = new Student(15, "Pepa");
Student karel = new Student(16, "Karel");

// Oba vidí stejný název školy
pepa.PrintInfo();  // Pepa, 15 let, Gymnázium
karel.PrintInfo(); // Karel, 16 let, Gymnázium
```

### 3. Kombinace statické a instanční metody
```csharp
// Statická metoda - výpis školy (bez potřeby instance)
Student.PrintSchool();

// Instanční metoda - výpis konkrétního studenta
pepa.PrintInfo();  // Pepa, 15 let, Gymnázium

// Instanční metoda může měnit statický atribut
karel.changeSchoolName("Nová škola");

// Změna se projeví u všech studentů
pepa.PrintInfo();  // Pepa, 15 let, Nová škola
karel.PrintInfo(); // Karel, 16 let, Nová škola
```

---

## Kdy použít co?

### Použij statickou třídu když:
- Vytváříš pomocné utility funkce
- Nepotřebuješ ukládat stav
- Příklad: matematické operace, konverze

### Použij statický atribut když:
- Hodnota má být sdílená všemi instancemi
- Počítáš instance třídy
- Příklad: název firmy, počet vytvořených objektů

### Použij statickou metodu když:
- Metoda nepotřebuje pracovat s konkrétní instancí
- Jedná se o pomocnou funkci
- Příklad: tovární metoda, validace formátu

### Použij instanční prvky když:
- Každý objekt má mít své vlastní hodnoty
- Pracuješ se stavem konkrétního objektu
- Příklad: jméno studenta, věk, email
