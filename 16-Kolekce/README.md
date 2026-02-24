# Kolekce v C#

Tento projekt demonstruje práci s nejpoužívanějšími kolekcemi v C#: `List<T>`, `Dictionary<TKey, TValue>`, `Queue<T>`, `Stack<T>` a `HashSet<T>`. Na praktických příkladech se třídou `Student` ukazuje, jak kolekce data ukládají, vyhledávají a odebírají.

## Co jsou kolekce?

- Kolekce jsou datové struktury pro ukládání více hodnot pod jedním názvem.
- Každý typ kolekce je optimalizovaný pro jiný způsob práce s daty.
- V C# jsou kolekce obvykle **generické** (`<T>`), takže jsou typově bezpečné.
- Typová bezpečnost znamená, že chyby se odhalí už při kompilaci.

**Klíčové výhody kolekcí:**
- **Přehlednost:** lepší organizace dat než samostatné proměnné
- **Výkon:** vhodný typ kolekce = rychlejší operace
- **Typová bezpečnost:** bez zbytečného přetypování
- **Flexibilita:** snadné přidávání a odebírání prvků

---

## Kolekce v tomto projektu

1. `List<int>` a `List<Student>` – pořadová kolekce
2. `Dictionary<string, Student>` – mapování klíč → hodnota
3. `Queue<Student>` – fronta (FIFO)
4. `Stack<Student>` – zásobník (LIFO)
5. `HashSet<Student>` – množina bez duplicitních referencí

---

## Třída Student

Projekt používá vlastní třídu `Student`, která je ukládána do více kolekcí:

```csharp
public class Student
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    public Student(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }

    public override string ToString()
    {
        return $"{Firstname} {Lastname}";
    }
}
```

**Klíčové prvky:**
- Konstruktor vyžaduje jméno a příjmení při vytvoření objektu
- `ToString()` usnadní výpis v kolekcích (`Console.WriteLine(student)`)

---

## 1) List<T> – uspořádaný seznam

`List<T>` je dynamické pole. Udržuje pořadí prvků a umožňuje rychlé přidávání na konec.

### Ukázka z projektu

```csharp
List<int> list = new List<int> { 1, 8, 3, 7 };
list.Sort();
Console.WriteLine("List<int> po seřazení: " + string.Join(", ", list));

Student x = new Student("Jiří", "Novák");
List<Student> students = new List<Student>
{
    new Student("Jan", "Novák"),
    new Student("Jana", "Svobodová")
};

students.Add(new Student("David", "Němec"));
students.Add(x);
students.Remove(x);
students.Clear();
```

### Použité operace

| Operace | Význam |
|---------|--------|
| `Sort()` | Seřadí prvky (u `int` vzestupně) |
| `Add()` | Přidá prvek na konec seznamu |
| `Remove()` | Odebere první výskyt daného prvku |
| `Clear()` | Vymaže celý seznam |

---

## 2) Dictionary<TKey, TValue> – klíč a hodnota

`Dictionary<TKey, TValue>` ukládá data jako dvojice **klíč → hodnota**.

### Ukázka z projektu

```csharp
Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>
{
    { "Jan", new Student("Jan", "Novák") },
    { "Jana", new Student("Jana", "Svobodová") }
};
studentDictionary.Add("David", new Student("David", "Němec"));

if (studentDictionary.ContainsKey("David"))
    Console.WriteLine("David je ve slovníku");

if (studentDictionary.ContainsValue(x))
    Console.WriteLine("Jiří Novák je ve slovníku");
else
    Console.WriteLine("Jiří Novák není ve slovníku");
```

### Důležité poznámky

- Klíče ve slovníku musí být unikátní.
- `ContainsKey()` kontroluje existenci klíče.
- `ContainsValue()` u referenčních typů kontroluje shodu objektu (reference), pokud nepřepíšete rovnost.

---

## 3) Queue<T> – fronta (FIFO)

`Queue<T>` funguje jako fronta: první vložený je první odebraný.

### Ukázka z projektu

```csharp
Queue<Student> messhall = new Queue<Student>();
messhall.Enqueue(new Student("Jan", "Novák"));
messhall.Enqueue(new Student("Jana", "Svobodová"));
messhall.Enqueue(new Student("David", "Němec"));

Console.WriteLine(messhall.Dequeue().Firstname);
Console.WriteLine(messhall.Dequeue().Firstname);

Student res;
var s = messhall.TryPeek(out res);
if (s) Console.WriteLine(res.Firstname);
else Console.WriteLine("Fronta je prázdná");
```

### Použité operace

| Operace | Význam |
|---------|--------|
| `Enqueue()` | Přidá prvek na konec fronty |
| `Dequeue()` | Odebere prvek z čela fronty |
| `TryPeek(out x)` | Bez odebrání vrátí první prvek, pokud existuje |

---

## 4) Stack<T> – zásobník (LIFO)

`Stack<T>` funguje jako zásobník: poslední vložený je první odebraný.

### Ukázka z projektu

```csharp
Stack<Student> stack = new Stack<Student>();
stack.Push(new Student("Jan", "Novák"));
stack.Push(new Student("Jana", "Svobodová"));

Console.WriteLine(stack.Pop().Firstname);

var s2 = stack.TryPeek(out res);
if (s2) Console.WriteLine(res.Firstname);
else Console.WriteLine("Zásobník je prázdný");
```

### Použité operace

| Operace | Význam |
|---------|--------|
| `Push()` | Vloží prvek na vrchol zásobníku |
| `Pop()` | Odebere prvek z vrcholu |
| `TryPeek(out x)` | Získá vrchol bez odebrání |

---

## 5) HashSet<T> – množina bez duplicit

`HashSet<T>` je kolekce unikátních prvků.

### Ukázka z projektu

```csharp
HashSet<Student> set = new HashSet<Student>();
set.Add(new Student("Jan", "Novák"));
set.Add(new Student("Jana", "Svobodová"));
set.Add(x);
set.Add(x);

foreach (var student in set)
{
    Console.WriteLine(student);
}
```

### Co je důležité v tomto projektu

- `set.Add(x)` volané podruhé nevloží nový prvek (stejná reference objektu `x`).
- U tříd bez přepsaných metod rovnosti (`Equals`, `GetHashCode`) se porovnává reference objektu.

---

## Rychlé srovnání kolekcí

| Kolekce | Pořadí | Unikátnost | Typické použití |
|---------|--------|------------|------------------|
| `List<T>` | Ano | Ne | Seznam položek, iterace, indexování |
| `Dictionary<TKey, TValue>` | Ne (logicky podle klíče) | Unikátní klíče | Rychlé vyhledávání podle klíče |
| `Queue<T>` | FIFO | Ne | Fronty úloh, zpracování v pořadí příchodu |
| `Stack<T>` | LIFO | Ne | Historie kroků, backtracking |
| `HashSet<T>` | Ne | Ano | Ověření unikátnosti, množinové operace |

---

## OOP principy v projektu

### 1. Zapouzdření
Třída `Student` skrývá vnitřní reprezentaci a nabízí práci přes vlastnosti a konstruktor.

### 2. Abstrakce
Kolekce abstrahují způsob ukládání dat – programátor pracuje přes jednotné API (`Add`, `Remove`, `Contains...`).

### 3. Typová bezpečnost (generika)
Každá kolekce jasně určuje, jaký typ dat obsahuje (`List<Student>`, `Queue<Student>`).


