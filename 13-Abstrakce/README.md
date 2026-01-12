# Abstrakce v C#

Tento projekt demonstruje koncept **abstrakce** v objektově orientovaném programování (OOP). Abstrakce vám umožňuje definovat společný rámec pro skupinu souvisejících tříd, aniž byste museli implementovat všechny detaily v základní třídě.

## Co je abstrakce?

- Abstraktní třída obsahuje abstraktní metody, které **musí být implementovány** v odvozených třídách.
- Nelze přímo instanciovat abstraktní třídu – můžete vytvořit jen instance odvozených konkrétních tříd.
- Definuje **"co"** musí děti dělat, ale ne **"jak"** to mají dělat.
- Kombinuje vlastnosti tříd s flexibilitou rozhraní (interface).

**Klíčový rozdíl od interface:**
- **Abstraktní třída**: může mít konkrétní implementaci i abstraktní metody, má stav (fields), konstruktory
- **Interface**: pouze smlouva, žádná implementace (před C# 8.0)

---

## Hierarchie v tomto projektu

```
Vehicle (abstraktní třída)
├── Car (konkrétní implementace)
└── Bus (konkrétní implementace)
```

---

## Vehicle - Abstraktní základní třída

### Struktura třídy

```csharp
public abstract class Vehicle
{
    // Vlastnosti - sdíleny všemi vozidly
    public string Color { get; set; }
    public int Capacity { get; set; }
    
    // Abstraktní metoda - musí být implementována v potomcích
    public abstract void Move();
    
    // Konkrétní metoda - sdílená všemi vozidly
    public void DisplayInfo()
    {
        Console.WriteLine($"Vozidlo má barvu: {Color}");
        Console.WriteLine($"Kapacita: {Capacity} míst");
    }
}
```

**Klíčové prvky:**
- `abstract` – označuje abstraktní třídu (nelze instanciovat)
- `public abstract void Move()` – abstraktní metoda bez těla; musí být přepsána v potomcích
- `public void DisplayInfo()` – konkrétní metoda; je zde implementace a všechny třídy ji zdědí
- Vlastnosti (`Color`, `Capacity`) jsou sdíleny všemi vozidly

**Proč takhle?**
- Chceme zajistit, aby každé vozidlo mělo barvu a kapacitu
- Chceme, aby každé vozidlo vědělo, jak se pohybuje, ale každý typ se pohybuje jinak
- Nechceme psát stejný kód (`DisplayInfo`) v každé třídě znovu

---

## Car - Konkrétní implementace

### Struktura třídy

```csharp
public class Car : Vehicle
{
    // Vlastnosti specifické pro auto
    public string RegistrationPlate { get; set; }
    public float MaxSpeed { get; set; }
    
    // Konstruktor
    public Car(string registrationPlate, float maxSpeed, string color)
    {
        RegistrationPlate = registrationPlate;
        MaxSpeed = maxSpeed;
        Color = color;
        Capacity = 5; // Auto má 5 míst
    }
    
    // Implementace abstraktní metody Move()
    public override void Move()
    {
        Console.WriteLine($"Auto s registrační značkou '{RegistrationPlate}' se pohybuje maximální rychlostí {MaxSpeed} km/h.");
    }
    
    // Override konkrétní metody DisplayInfo()
    public override void DisplayInfo()
    {
        Console.WriteLine($"\n--- AUTOMOBIL ---");
        base.DisplayInfo(); // Zavolá implementaci z Vehicle
        Console.WriteLine($"Registrační značka: {RegistrationPlate}");
        Console.WriteLine($"Maximální rychlost: {MaxSpeed} km/h");
    }
    
    // Vlastní metoda
    public string GetDescription()
    {
        return $"Osobní automobil {RegistrationPlate} ({Color})";
    }
}
```

**Klíčové prvky:**
- `: Vehicle` – dědí z abstraktní třídy `Vehicle`
- `public override void Move()` – **povinná** implementace abstraktní metody
- `public override void DisplayInfo()` – volitelné přepsání konkrétní metody
- `base.DisplayInfo()` – volá implementaci ze základní třídy a přidává vlastní text
- Vlastní vlastnosti (`RegistrationPlate`, `MaxSpeed`) a metody (`GetDescription()`)

---

## Bus - Konkrétní implementace

### Struktura třídy

```csharp
public class Bus : Vehicle
{
    // Private pole s validací
    private int _passengers = 0;
    
    public int Passengers
    {
        get { return _passengers; }
        set
        {
            // Validace - počet pasažérů nemůže překročit kapacitu
            if (Capacity < value)
            {
                throw new ArgumentException($"Překročena kapacita autobusu! Maximální počet pasažérů: {Capacity}, pokus: {value}");
            }
            _passengers = value;
        }
    }
    
    // Konstruktor
    public Bus(int capacity, string color)
    {
        Capacity = capacity;
        Color = color;
        _passengers = 0;
    }
    
    // Implementace abstraktní metody Move()
    public override void Move()
    {
        Console.WriteLine($"Autobus jede s {Passengers}/{Capacity} pasažéry.");
    }
}
```

**Klíčové prvky:**
- Validace v property setter – zajišťuje, že počet pasažérů nikdy nepřekročí kapacitu
- Konstruktor nastavuje kapacitu (liší se od auta)
- Implementace `Move()` je specifická pro autobus
- Nedědí `DisplayInfo()` ze základní třídy, používá ji tak, jak je

---

## Abstraktní vs. konkrétní metoda

| Aspekt | Abstraktní metoda | Konkrétní metoda |
|--------|-------------------|------------------|
| **Klíčové slovo** | `abstract` | Normální (nebo `virtual`) |
| **Tělo** | Žádné (jen `;`) | Má implementaci |
| **Povinnost** | Musí se implementovat | Lze přepsat (override) nebo zdědit |
| **Příklad** | `public abstract void Move();` | `public void DisplayInfo() { ... }` |

---

## Polymorfní volání

Klíčová výhoda: Můžete pracovat s polem či listinou vozidel bez znalosti konkrétního typu.

```csharp
Vehicle[] vehicles = 
{
    new Car("4A5 4581", 120, "modré"),
    new Bus(45, "zelené"),
    new Bus(50, "červené")
};

// Polymorfní volání - zavolá správnou implementaci Move()
foreach (var vehicle in vehicles)
{
    vehicle.Move(); // Každý typ se pohybuje jinak
    vehicle.DisplayInfo();
}
```

**Co se stane:**
- `Car.Move()`: "Auto s registrační značkou '4A5 4581' se pohybuje maximální rychlostí 120 km/h."
- `Bus.Move()`: "Autobus jede s 0/45 pasažéry."

---

## Type checking s `is` a `as`

Někdy potřebujete poznat, jaký konkrétní typ vozidla máte:

```csharp
foreach (var vehicle in vehicles)
{
    // Varianта 1: is pattern (doporučeno)
    if (vehicle is Car car)
    {
        Console.WriteLine($"Auto: {car.GetDescription()}");
        car.Move();
    }
    else if (vehicle is Bus bus)
    {
        Console.WriteLine($"Autobus s kapacitou {bus.Capacity}");
        bus.Move();
    }   
  
}
```

**Klíčový rozdíl:**
- `is` – jen zkontroluje typ, vrátí `true`/`false`
- `is Car car` – zkontroluje typu a zároveň ho "rozpákouje" do nové proměnné
- `as` – pokusí se konvertovat; vrátí `null` při selhání

---

## Zapouzdření s validací (Bus - příklad)

Bus demonstruje, jak abstraktní třídy umožňují bezpečnější manipulaci s daty:

```csharp
Bus autobus = new Bus(45, "zelené");

// ✅ Funguje - validace projde
autobus.Passengers = 30;

// ❌ Vyhodí výjimku - překročena kapacita
try
{
    autobus.Passengers = 50;
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Chyba: {ex.Message}");
    // Výstup: Chyba: Překročena kapacita autobusu! Maximální počet pasažérů: 45, pokus: 50
}
```

---

## Abstraktní třída vs. Interface

### Kdy použít abstraktní třídu:

✅ Když třídy mají **společný stav** (fields)  
✅ Když třídy mají **konstruktory** se logikou  
✅ Když chcete **částečnou implementaci** (mix abstraktních a konkrétních metod)  
✅ Když chcete **access modifiers** jiné než public  
✅ Když máte **IS-A relaci** (auto IS-A vozidlo)

### Příklad:

```csharp
// ✅ Dobrý případ pro abstraktní třídu
abstract class Vehicle
{
    public string Color { get; set; } // Stav - všechna vozidla mají barvu
    public abstract void Move(); // Každé se pohybuje jinak
    public void DisplayInfo() { ... } // Sdílená logika
}

// ❌ Nedává smysl interface (potřebujeme stav a konstruktor)
// interface IVehicle { }
```

### Kdy použít interface:

✅ Když třídy nemají **společný stav**  
✅ Když chcete **více dědičnost** (třída může implementovat víc rozhraní)  
✅ Když chcete jen **definovat smlouvu** ("co" se dělá)  
✅ Když máte **HAS-A nebo CAN-DO relaci** (třída "umí" dělat něco)

---

## Praktické příklady z projektu

### Příklad 1: Vytvoření vozidel

```csharp
// Nelze přímou instanciaci abstraktní třídy
// Vehicle v = new Vehicle(); // ❌ Chyba: Cannot instantiate abstract type

// Lze jen prostřednictvím konkrétních tříd
Car moje_auto = new Car("4A5 4581", 120, "modré");
Bus mestni_autobus = new Bus(45, "zelené");
```

### Příklad 2: Polymorfní pole

```csharp
// Pole typu Vehicle, ale obsahuje Car a Bus instance
Vehicle[] vozidla = 
{
    new Car("ABC 1234", 160, "červené"),
    new Bus(50, "bílé"),
    new Car("XYZ 9999", 180, "černé"),
    new Bus(30, "modré")
};

// Všechna vozidla si "cestují" svým způsobem
foreach (var vozidlo in vozidla)
{
    vozidlo.Move(); // Polymorfní volání
}
```

### Příklad 3: Kontrola typu a práce se specifickými metodami

```csharp
foreach (var vozidlo in vozidla)
{
    if (vozidlo is Car auto)
    {
        Console.WriteLine($"Osobní auto: {auto.GetDescription()}");
        Console.WriteLine($"Maximální rychlost: {auto.MaxSpeed} km/h");
    }
    else if (vozidlo is Bus autobus)
    {
        Console.WriteLine($"Autobus ({autobus.Color}) pro {autobus.Capacity} lidí");
        autobus.Passengers = 25;
        autobus.Move();
    }
}
```

---

## Výhody abstrakce

| Výhoda | Vysvětlení |
|--------|-----------|
| **Modulárnost** | Rozlišujete rozhraní (co se dělá) od implementace (jak se to dělá) |
| **Rozšiřitelnost** | Snadno přidáte nový typ vozidla (Truck, Motorcycle) bez změny existujícího kódu |
| **Polymorfismus** | Jednotný kód pro různé typy; volá se správná metoda za běhu |
| **Bezpečnost typů** | Compiler hlídá, že všechny abstraktní metody jsou implementovány |
| **Zapouzdření** | Skryté detaily, přístup jen k důležitým věcem (public rozhraní) |
| **Udržitelnost** | Změny v abstraktní třídě se projeví ve všech potomcích |

---

## OOP Principy v tomto projektu

### 1. Abstrakce
Abstraktní třída `Vehicle` skrývá složitost různých typů vozidel za jednoduché rozhraní.

### 2. Dědičnost
`Car` a `Bus` dědí z `Vehicle` a získávají `Color`, `Capacity` a `DisplayInfo()`.

### 3. Polymorfismus
Metoda `Move()` se chová jinak podle skutečného typu objektu (`Car` vs. `Bus`).

### 4. Zapouzdření
- `Bus.Passengers` má getter/setter s validací
- Private field `_passengers` je chráněn před přímým přístupem

---

## Klíčové koncepty

| Koncept | Popis |
|---------|-------|
| **abstract** | Třída/metoda bez úplné implementace; vyžaduje doplnění v potomcích |
| **override** | Přepsání metody ze základní třídy v třídě odvozené |
| **virtual** | Metoda, kterou lze přepsat (implicitní u abstraktních) |
| **base.** | Volání metody ze základní třídy |
| **is** | Kontrola typu; `if (obj is Car)` |
| **as** | Konverze typu; vrátí `null` při selhání |

---
