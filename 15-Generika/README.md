# Generika v C#

Tento projekt demonstruje koncept **generik (generics)** v C#. Generika umožňují vytvářet třídy, metody a rozhraní, které pracují s různými datovými typy, aniž byste museli psát duplicitní kód pro každý typ zvlášť.

## Co jsou generika?

- Generická třída nebo metoda může pracovat s **libovolným datovým typem**
- Typový parametr (např. `T`) se určí až při použití třídy nebo metody
- Zvyšuje **typovou bezpečnost** - chyby se zjistí při kompilaci, ne až za běhu
- Eliminuje nutnost **type castingu** a používání `object`
- Umožňuje **znovupoužitelnost kódu** - jedna implementace pro mnoho typů

**Klíčové výhody:**
- **Typová bezpečnost**: Compiler hlídá správné použití typů
- **Výkon**: Žádný boxing/unboxing u hodnotových typů
- **Čitelnost**: Jasné, jaký typ se používá
- **Znovupoužitelnost**: Jedna třída/metoda pro všechny typy

---

## Třídy v tomto projektu

### 1. Box\<T> - Základní generická třída
### 2. Scitac\<T> - Generika s omezením (constraints)
### 3. Pair\<TKey, TValue> - Více typových parametrů
### 4. Printer - Generická statická metoda

---

## Box\<T> - Základní generická třída

### Struktura třídy

```csharp
public class Box<T>
{
    private T item;

    public Box(T item)
    {
        this.item = item;
    }

    public void Store(T item)
    {
        this.item = item;
    }

    public T GetItem()
    {
        return item;
    }
}
```

**Klíčové prvky:**
- `<T>` - typový parametr (může být libovolný název, ale konvence je `T`)
- `private T item` - proměnná typu `T`
- Metody pracují s typem `T` bez znalosti konkrétního typu
- Typ se určí až při vytvoření instance

### Použití

```csharp
// Box pro celá čísla
Box<int> intBox = new Box<int>(5);
intBox.Store(42);
int number = intBox.GetItem(); // number = 42
Console.WriteLine(number);      // Vypíše: 42

// Box pro text
Box<string> stringBox = new Box<string>("Ahoj");
stringBox.Store("Hello");
string text = stringBox.GetItem(); // text = "Hello"

// Box pro vlastní třídu
Box<Person> personBox = new Box<Person>(new Person("Jan"));
```

**Proč je to užitečné?**

Bez generik bychom museli:
```csharp
// ❌ Varianta 1: Samostatná třída pro každý typ
public class IntBox { private int item; ... }
public class StringBox { private string item; ... }
public class PersonBox { private Person item; ... }

// ❌ Varianta 2: Použití object (nebezpečné!)
public class Box
{
    private object item;
    public object GetItem() { return item; } // Musíme castovat
}
// Použití:
Box box = new Box();
box.Store(42);
int number = (int)box.GetItem(); // Může selhat za běhu!
```

---

## Scitac\<T> - Generika s omezením

### Struktura třídy

```csharp
public class Scitac<T> where T : INumber<T>
{
    protected T _value;
    public T Value { get { return _value; } }

    public Scitac(T value)
    {
        _value = value;
    }

    public T secti(T number)
    {
        return _value + number; // Lze sčítat díky INumber<T>
    }
}
```

**Klíčové prvky:**
- `where T : INumber<T>` - **omezení typu** (type constraint)
- `T` musí implementovat rozhraní `INumber<T>`
- To umožňuje používat operátor `+` pro sčítání
- Funguje pro `int`, `double`, `decimal`, `float` atd.

### Použití

```csharp
// Pro celá čísla
Scitac<int> intScitac = new Scitac<int>(5);
Console.WriteLine(intScitac.secti(3));  // Vypíše: 8

// Pro desetinná čísla
Scitac<double> doubleScitac = new Scitac<double>(5.5);
Console.WriteLine(doubleScitac.secti(3.7));  // Vypíše: 9.2

// Pro decimal
Scitac<decimal> decimalScitac = new Scitac<decimal>(10.5m);
Console.WriteLine(decimalScitac.secti(2.3m));  // Vypíše: 12.8
```

**Proč omezení?**

Bez omezení `where T : INumber<T>` bychom nemohli použít operátor `+`:

```csharp
// ❌ Nefunguje - T může být cokoliv (string, bool, ...)
public class Scitac<T>
{
    public T secti(T a, T b)
    {
        return a + b; // CHYBA: operátor + není definován pro T
    }
}

// ✅ Funguje - T je omezen na číselné typy
public class Scitac<T> where T : INumber<T>
{
    public T secti(T a, T b)
    {
        return a + b; // OK - INumber<T> podporuje sčítání
    }
}
```

---

## Pair\<TKey, TValue> - Více typových parametrů

### Struktura třídy

```csharp
public class Pair<TKey, TValue>
{
    // Vlastnosti pro klíč a hodnotu
    public TKey Key { get; set; }
    public TValue Value { get; set; }

    // Konstruktor
    public Pair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    // Přepsání ToString pro výpis
    public override string ToString()
    {
        return $"Key: {Key}, Value: {Value}";
    }
}
```

**Klíčové prvky:**
- `<TKey, TValue>` - dva typové parametry
- Konvence: použít popisné názvy (`TKey`, `TValue`) místo jen `T`, `U`
- Každý parametr může být jiný typ
- Podobné jako `KeyValuePair<TKey, TValue>` v .NET

### Použití

```csharp
// Pár string-int (např. jméno-věk)
var numberPair = new Pair<string, int>("Věk", 25);
Console.WriteLine(numberPair);  // Vypíše: Key: Věk, Value: 25

// Pár int-string (např. ID-jméno)
var textPair = new Pair<int, string>(1, "První");
Console.WriteLine(textPair);    // Vypíše: Key: 1, Value: První

// Pár string-double (např. produkt-cena)
var productPair = new Pair<string, double>("Laptop", 25999.99);
Console.WriteLine(productPair); // Vypíše: Key: Laptop, Value: 25999.99

// Pár DateTime-string (např. datum-událost)
var eventPair = new Pair<DateTime, string>(DateTime.Now, "Narozeniny");
```

**Praktické použití:**

```csharp
// Seznam párů (slovník ručně vytvořený)
var dictionary = new List<Pair<string, int>>
{
    new Pair<string, int>("Jablka", 5),
    new Pair<string, int>("Hrušky", 3),
    new Pair<string, int>("Banány", 7)
};

foreach (var item in dictionary)
{
    Console.WriteLine($"{item.Key}: {item.Value} ks");
}
// Výstup:
// Jablka: 5 ks
// Hrušky: 3 ks
// Banány: 7 ks
```

---

## Printer - Generická statická metoda

### Struktura metody

```csharp
internal class Printer
{
    public static void Print<T>(T value)
    {
        Console.WriteLine($"hodnota: {value}");
    }
}
```

**Klíčové prvky:**
- `<T>` za názvem metody - generická metoda (ne třída)
- `static` - lze volat bez instance třídy
- Typ se určí z parametru nebo explicitně
- Funguje pro jakýkoliv typ

### Použití

```csharp
// Explicitní určení typu
Printer.Print<int>(10);          // hodnota: 10
Printer.Print<string>("Ahoj");   // hodnota: Ahoj
Printer.Print<double>(3.14);     // hodnota: 3.14

// Implicitní určení typu (type inference)
Printer.Print(10);          // Compiler odvodí <int>
Printer.Print("Ahoj");      // Compiler odvodí <string>
Printer.Print(3.14);        // Compiler odvodí <double>

// Vlastní třídy
Printer.Print(new Person("Jan")); // hodnota: Jan
```

**Porovnání:**

```csharp
// ❌ Bez generik - musíme psát metodu pro každý typ
public static void PrintInt(int value) { ... }
public static void PrintString(string value) { ... }
public static void PrintDouble(double value) { ... }

// ✅ S generikami - jedna metoda pro všechno
public static void Print<T>(T value) { ... }
```

---

## Omezení typů (Type Constraints)

Omezení definují, jaké typy lze použít jako typový parametr.

### Běžná omezení

| Omezení | Význam | Příklad |
|---------|--------|---------|
| `where T : class` | T musí být referenční typ | `string`, `Person`, `List<int>` |
| `where T : struct` | T musí být hodnotový typ | `int`, `double`, `DateTime` |
| `where T : new()` | T musí mít bezparametrický konstruktor | `new T()` |
| `where T : BaseClass` | T musí dědit z `BaseClass` | Dědičnost |
| `where T : IInterface` | T musí implementovat rozhraní | `IComparable`, `INumber<T>` |
| `where T : U` | T musí být nebo dědit z `U` | Vztah mezi parametry |

### Příklady omezení

```csharp
// Pouze referenční typy
public class Repository<T> where T : class
{
    private List<T> items = new List<T>();
    public void Add(T item) => items.Add(item);
}

// Pouze typy s prázdným konstruktorem
public class Factory<T> where T : new()
{
    public T Create()
    {
        return new T(); // Lze vytvořit novou instanci
    }
}

// Kombinace omezení
public class Manager<T> where T : class, IComparable<T>, new()
{
    // T musí být třída, implementovat IComparable<T> a mít konstruktor
}

// Více parametrů s omezením
public class Converter<TInput, TOutput> 
    where TInput : IConvertible
    where TOutput : new()
{
    public TOutput Convert(TInput input) { ... }
}
```

---

## Výhody generik

| Výhoda | Vysvětlení |
|--------|-----------|
| **Typová bezpečnost** | Chyby se zachytí při kompilaci, ne až za běhu |
| **Eliminace castování** | Nemusíte přetypovávat z `object` |
| **Výkon** | Žádný boxing/unboxing u hodnotových typů (`int`, `double`) |
| **Znovupoužitelnost** | Jeden kód pro mnoho typů |
| **Čitelnost** | Jasně vidíte, s jakým typem pracujete |
| **IntelliSense** | IDE nabízí správné metody a vlastnosti |

---

## Generika vs. Object

### Bez generik (špatný přístup)

```csharp
public class OldBox
{
    private object item;
    
    public void Store(object item)
    {
        this.item = item;
    }
    
    public object GetItem()
    {
        return item;
    }
}

// Použití
OldBox box = new OldBox();
box.Store(42);
int number = (int)box.GetItem(); // ❌ Musíme castovat

box.Store("text");
int wrong = (int)box.GetItem(); // ❌ Runtime exception!
```

**Problémy:**
- Nutné typové konverze (casting)
- Chyby se projeví až za běhu
- Boxing/unboxing u hodnotových typů (pomalé)
- Žádná nápověda IntelliSense

### S generikami (správný přístup)

```csharp
public class Box<T>
{
    private T item;
    
    public void Store(T item)
    {
        this.item = item;
    }
    
    public T GetItem()
    {
        return item;
    }
}

// Použití
Box<int> intBox = new Box<int>();
intBox.Store(42);
int number = intBox.GetItem(); // ✅ Žádné castování

Box<string> stringBox = new Box<string>();
stringBox.Store(42); // ❌ Compile error - nelze uložit int do Box<string>
```

**Výhody:**
- Žádné castování
- Chyby se zachytí při kompilaci
- Žádný boxing/unboxing
- IntelliSense funguje perfektně

---

## Generické kolekce v .NET

C# obsahuje mnoho vestavěných generických kolekcí:

```csharp
// List<T> - dynamické pole
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
List<string> names = new List<string> { "Jan", "Eva", "Petr" };

// Dictionary<TKey, TValue> - slovník (klíč-hodnota)
Dictionary<string, int> ages = new Dictionary<string, int>
{
    { "Jan", 30 },
    { "Eva", 25 },
    { "Petr", 35 }
};

// Queue<T> - fronta (FIFO)
Queue<string> queue = new Queue<string>();
queue.Enqueue("První");
queue.Enqueue("Druhý");
string first = queue.Dequeue(); // "První"

// Stack<T> - zásobník (LIFO)
Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
int top = stack.Pop(); // 2

// HashSet<T> - množina (bez duplicit)
HashSet<int> uniqueNumbers = new HashSet<int> { 1, 2, 3, 3, 2 };
// Obsahuje: 1, 2, 3 (duplicity odstraněny)
```

---

## Praktické příklady z projektu

### Příklad 1: Box pro různé typy

```csharp
// Box pro čísla
Box<int> intBox = new Box<int>(5);
intBox.Store(42);
Console.WriteLine(intBox.GetItem());    // 42

// Box pro text
Box<string> stringBox = new Box<string>("Počáteční text");
stringBox.Store("Nový text");
Console.WriteLine(stringBox.GetItem()); // Nový text

// Box pro vlastní třídu
Box<Person> personBox = new Box<Person>(new Person("Jan"));
Person person = personBox.GetItem();
```

### Příklad 2: Sčítání různých číselných typů

```csharp
// Celá čísla
Scitac<int> intScitac = new Scitac<int>(10);
Console.WriteLine(intScitac.secti(5));    // 15

// Desetinná čísla
Scitac<double> doubleScitac = new Scitac<double>(10.5);
Console.WriteLine(doubleScitac.secti(3.7)); // 14.2

// Peníze (decimal)
Scitac<decimal> moneyScitac = new Scitac<decimal>(100.50m);
Console.WriteLine(moneyScitac.secti(25.75m)); // 126.25
```

### Příklad 3: Páry různých typů

```csharp
// Slovník (manuální)
var items = new List<Pair<string, int>>
{
    new Pair<string, int>("Laptop", 1),
    new Pair<string, int>("Myš", 3),
    new Pair<string, int>("Klávesnice", 2)
};

foreach (var item in items)
{
    Console.WriteLine($"{item.Key}: {item.Value} ks");
}

// Nastavení (klíč-hodnota)
var settings = new List<Pair<string, string>>
{
    new Pair<string, string>("Theme", "Dark"),
    new Pair<string, string>("Language", "CS"),
    new Pair<string, string>("Font", "Consolas")
};
```

### Příklad 4: Generická metoda

```csharp
// Různé typy
Printer.Print(42);              // hodnota: 42
Printer.Print("Hello");         // hodnota: Hello
Printer.Print(3.14159);         // hodnota: 3.14159
Printer.Print(true);            // hodnota: True
Printer.Print(DateTime.Now);    // hodnota: 03.02.2026 14:30:00
```

---

## Konvence pojmenování

| Konvence | Použití | Příklad |
|----------|---------|---------|
| `T` | Jeden typový parametr | `Box<T>`, `List<T>` |
| `T`, `U` | Dva obecné parametry | `Func<T, U>` |
| `TKey`, `TValue` | Klíč a hodnota | `Dictionary<TKey, TValue>` |
| `TInput`, `TOutput` | Vstup a výstup | `Converter<TInput, TOutput>` |
| `TEntity` | Databázová entita | `Repository<TEntity>` |
| `TResult` | Výsledek operace | `Task<TResult>` |

**Pravidlo:** Vždy začínat písmenem `T` pro typový parametr.

---

## Kdy použít generika?

### ✅ Použít generika když:

- Vytváříte **kolekce nebo kontejnery** (Box, List, ...)
- Píšete **stejnou logiku pro různé typy** (Printer)
- Potřebujete **typovou bezpečnost** bez duplicity kódu
- Pracujete s **datovými strukturami** (Stack, Queue, Tree, ...)
- Implementujete **repository pattern** nebo **factory pattern**

### ❌ Nepoužívat generika když:

- Logika je **specifická pro jeden typ**
- Potřebujete přistupovat ke **konkrétním vlastnostem** typu
- Přidávají **zbytečnou složitost** bez přínosu
- Typ je už **jasně daný** a nemění se

---

## Shrnutí klíčových konceptů

### Typové parametry:
✅ `<T>` - obecný typový parametr  
✅ `<TKey, TValue>` - více parametrů s popisnými názvy  
✅ Určuje se při vytváření instance nebo volání metody  
✅ Poskytuje typovou bezpečnost

### Omezení (Constraints):
- `where T : class` - referenční typ
- `where T : struct` - hodnotový typ
- `where T : new()` - musí mít konstruktor
- `where T : INumber<T>` - implementuje rozhraní

### Výhody:
- **Bezpečnost** - chyby při kompilaci
- **Výkon** - žádný boxing/unboxing
- **Čitelnost** - jasné typy
- **Znovupoužitelnost** - jeden kód pro všechny typy

### Běžné použití:
- Kolekce (`List<T>`, `Dictionary<TKey, TValue>`)
- Kontejnery (`Box<T>`)
- Utility třídy (`Printer`)
- Repository pattern
- Factory pattern

---

## OOP Principy v tomto projektu

### 1. Abstrakce
Generika abstrahují konkrétní typ - Box funguje stejně pro int i string.

### 2. Zapouzdření
Private pole `item` je chráněno, přístup jen přes metody `Store()` a `GetItem()`.

### 3. Znovupoužitelnost
Jedna třída (`Box<T>`) funguje pro nekonečně mnoho typů.

### 4. Typová bezpečnost
Compiler hlídá správné použití typů - nelze uložit `int` do `Box<string>`.

---
