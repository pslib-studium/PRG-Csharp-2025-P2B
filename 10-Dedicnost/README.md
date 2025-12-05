# Dědičnost v C#

Tento projekt demonstruje základní koncepty objektově orientovaného programování - dědičnosti a polymorfismu v C#.

## Co je dědičnost?

**Dědičnost** je mechanismus, který umožňuje třídě (zděděné třídě) převzít vlastnosti a metody jiné třídy (základní třída). Umožňuje nám vytvářet hierarchii tříd a opakovaně používat kód.

**Základní třída (Base class)** - třída, ze které dědíme  
**Odvozená třída (Derived class)** - třída, která dědí

---

## Syntaxe dědičnosti

V C# se dědičnost vyjadřuje pomocí znaku `:` (dvoutečka).

```csharp
// Odvozená třída Student dědí z základní třídy Person
public class Student : Person
{
    // Student má všechny vlastnosti a metody z Person
    // Plus své vlastní specifické vlastnosti
}
```

---

## Hierarchie v tomto projektu

```
Person (základní třída)
├── Student (odvozená třída)
└── Teacher (odvozená třída)
```

### Person - Základní třída

```csharp
public class Person
{
    protected string _firstName;   // Chráněné - dostupné jen pro odvozené třídy
    protected string _lastName;
    private int _age;              // Soukromé - dostupné jen v tomto objektu

    // Konstruktor
    public Person(string firstName, string lastName, int age) { ... }

    // Vlastnosti
    public bool IsAdult { get; }       // Kontroluje, zda je osoba plnoletá
    public string FullName { get; }    // Vrací celé jméno
}
```

**Klíč:**
- `protected` - dostupné v odvozených třídách a v jejich vlastní třídě
- `private` - dostupné pouze v téže třídě

### Student - Odvozená třída

```csharp
public class Student : Person  // Dědí z Person
{
    public string ClassName { get; set; }  // Specifické pro studenta

    public Student(string firstName, string lastName, int age, string className)
            : base(firstName, lastName, age)  // Volá konstruktor základní třídy
    {
        ClassName = className;
    }

    // Vlastní metoda
    public string Info() { ... }
}
```

**Klíč:**
- `:` - dědičnost
- `: base(...)` - volání konstruktoru základní třídy

### Teacher - Odvozená třída

```csharp
public class Teacher : Person  // Dědí z Person
{
    public string? TitleBefore { get; set; }  // Titul před jménem (např. "Mgr.")
    public string? TitleAfter { get; set; }   // Titul za jménem (např. "PhD.")

    public Teacher(string firstName, string lastName, int age, 
        string? titleBefore = null, string? titleAfter = null) : base(firstName, lastName, age)
    {
        TitleBefore = titleBefore;
        TitleAfter = titleAfter;
    }

    public string Info() { ... }
}
```

---

## Modifikátory přístupu

| Modifikátor | V třídě | V odvozené třídě | Mimo třídu |
|-------------|--------|-----------------|-----------|
| `private` | ✅ Ano | ❌ Ne | ❌ Ne |
| `protected` | ✅ Ano | ✅ Ano | ❌ Ne |
| `public` | ✅ Ano | ✅ Ano | ✅ Ano |
| (bez označení) | ✅ Ano | ❌ Ne | ❌ Ne |

### Příklad v našem projektu:

```csharp
public class Person
{
    protected string _firstName;    // Student a Teacher můžou přistupovat
    private int _age;               // Pouze Person může přistupovat
    public string FullName { get; } // Všichni mohou přistupovat
}

public class Student : Person
{
    public string Info()
    {
        // ✅ Funguje - protected je dostupné v odvozené třídě
        string lastName = base._lastName;
        
        // ✅ Funguje - veřejné vlastnosti
        string fullName = base.FullName;
        bool adult = base.IsAdult;
        
        // ❌ Nefunguje - private není dostupné
        // int age = this._age;
    }
}
```

---

## Klíčové slovo `base`

Klíčové slovo `base` odkazuje na základní třídu.

### Volání konstruktoru základní třídy:

```csharp
public class Student : Person
{
    public Student(string firstName, string lastName, int age, string className)
            : base(firstName, lastName, age)  // Volá konstruktor Person
    {
        ClassName = className;
    }
}
```

### Přístup ke členům základní třídy:

```csharp
public class Student : Person
{
    public string Info()
    {
        string status = base.IsAdult ? "je plnoletý" : "není plnoletý";
        return $"{base._lastName} chodí do {ClassName} a {status}";
    }
}
```

---

## Polymorfismus

Polymorfismus (mnohavrstevnost) umožňuje odvozeným třídám přepsat metody základní třídy.

### Přepsání metody (Override)

```csharp
public class Person
{
    public virtual string Info()  // virtual - může být přepsáno
    {
        return FullName;
    }
}

public class Student : Person
{
    public override string Info()  // override - přepisujeme metodu
    {
        return $"{_lastName} chodí do {ClassName}";
    }
}

public class Teacher : Person
{
    public override string Info()
    {
        return $"{TitleBefore}{FullName}{TitleAfter}";
    }
}
```

### Polymorfní volání

```csharp
Person[] people = {
    new Student("Alice", "Nováková", 17, "E3C"),
    new Teacher("Karel", "Novotný", 58, "Mgr."),
    new Person("Tomáš", "Nesvačil", 44)
};

// Polymorfní volání - zavolá správnou metodu podle typu objektu
foreach (Person person in people) {
    Console.WriteLine(person.Info());  // Každá třída má svou implementaci
}
```

---

## Praktické příklady z projektu

### Příklad 1: Vytvoření studentky

```csharp
Student alice = new Student("Alice", "Nováková", 17, "E3C");

// Přístup ke zděděným vlastnostem
Console.WriteLine(alice.FullName);  // "Alice Nováková"
Console.WriteLine(alice.IsAdult);   // false (je mladší než 18)

// Vlastní vlastnost
Console.WriteLine(alice.ClassName); // "E3C"

// Vlastní metoda
Console.WriteLine(alice.Info());    // "Nováková chodí do E3C a není plnoletá"
```

### Příklad 2: Vytvoření učitele

```csharp
Teacher novotny = new Teacher("Karel", "Novotný", 58, "Mgr.");

// Přístup ke zděděným vlastnostem
Console.WriteLine(novotny.FullName);  // "Karel Novotný"
Console.WriteLine(novotny.IsAdult);   // true

// Vlastní vlastnosti
Console.WriteLine(novotny.TitleBefore); // "Mgr."

// Vlastní metoda
Console.WriteLine(novotny.Info());    // "Mgr. Karel Novotný"
```

### Příklad 3: Polymorfní pole

```csharp
// Jedno pole obsahuje všechny typy osob
Person[] people = {
    new Student("Alice", "Nováková", 17, "E3C"),
    new Teacher("Karel", "Novotný", 58, "Mgr."),
    new Student("Petr", "Dvořák", 15, "P1A"),
    new Person("Tomáš", "Nesvačil", 44)
};

// Všichni jsou typu Person, ale zachovávají svůj skutečný typ
foreach (Person person in people) {
    Console.WriteLine(person.FullName);  // Všichni mají tuto vlastnost
}
```

---

## Shrnutí klíčových konceptů

### Dědičnost:
✅ Odvozená třída zdědí všechny veřejné a chráněné členy  
✅ Umožňuje opakovaně používat kód  
✅ Vytváří hierarchii tříd  
✅ Řeší problém "je typu" (Student "je" Person)

### Modifikátory přístupu:
- `private` - jen v téže třídě
- `protected` - v téže třídě a v odvozených třídách
- `public` - všude

### Klíčové slovo `base`:
- `base(...)` - volání konstruktoru základní třídy
- `base.Member` - přístup ke členům základní třídy

### Polymorfismus:
- `virtual` - základní třída označí, že metoda může být přepsána
- `override` - odvozená třída přepisuje metodu
- Umožňuje volat správnou metodu podle skutečného typu objektu

---

## Kdy použít dědičnost?

✅ Když máš sdílené vlastnosti a chování (Person -> Student, Teacher)  
✅ Když chceš vytvořit hierarchii typů  
✅ Když chceš opakovaně používat kód  
✅ Když potřebuješ polymorfismus  

❌ Nepoužívej, když není jasná hierarchie "je typu"  
❌ Nepoužívej pro jednoduché sdílení kódu (spíš kompozici)

---

## Složitější příklad - Filtrování osob

```csharp
// Pole všech typů osob
Person[] people = {
    new Student("Alice", "Nováková", 17, "E3C"),
    new Teacher("Karel", "Novotný", 58, "Mgr."),
    new Student("Petr", "Dvořák", 15, "P1A")
};

// Filtrování pouze na studenty
foreach (Person person in people) {
    if (person is Student student)  // Polymorfní kontrola typu
    {
        Console.WriteLine($"{student.FullName} je ve třídě {student.ClassName}");
    }
}

// Filtrování pouze na učitele
foreach (Person person in people) {
    if (person is Teacher teacher)
    {
        Console.WriteLine($"{teacher.FullName} má titul {teacher.TitleBefore}");
    }
}
```

---

## Vztah mezi třídami v tomto projektu

```
┌─────────────┐
│    Person   │  (základní třída - obsahuje společné vlastnosti)
│─────────────│
│ - firstName │
│ - lastName  │
│ - age       │
│─────────────│
│ + FullName  │
│ + IsAdult   │
└─────────────┘
     ▲
     │ dědí
     ├─────────────────────┬───────────────────────┐
     │                     │                       │
┌─────────────┐      ┌──────────────┐        (další odvozené třídy...)
│   Student   │      │   Teacher    │
├─────────────┤      ├──────────────┤
│ClassName   │      │ TitleBefore  │
│             │      │ TitleAfter   │
├─────────────┤      ├──────────────┤
│ + Info()    │      │ + Info()     │
└─────────────┘      └──────────────┘
```

---

## Výstup z Program.cs

Program demonstruje:
1. Vytvoření instancí Student a Teacher
2. Přístup ke zděděným vlastnostem
3. Přístup k vlastním vlastnostem
4. Volání vlastních metod
5. Polymorfní pole obsahující všechny typy osob
6. Iteraci přes polymorfní pole a výpis jmen
