# LINQ v C#

Tento projekt demonstruje základy práce s **LINQ** nad kolekcí objektů `Student`. LINQ umožňuje jednoduše filtrovat, řadit, vybírat a seskupovat data čitelným způsobem přímo v C# kódu.

## Co je LINQ?

- LINQ znamená **Language Integrated Query**.
- Umožňuje psát dotazy nad kolekcemi pomocí metod jako `Where()`, `OrderBy()`, `Take()` nebo `GroupBy()`.
- Nejčastěji se používá nad seznamy, poli, databázovými dotazy nebo XML.
- Pomáhá zkrátit kód a zároveň zachovat dobrou čitelnost.

**Klíčové výhody LINQ:**
- **Čitelnost:** dotaz obvykle přesně popisuje, co chceme s daty udělat
- **Přehlednost:** filtrování, řazení i seskupení jsou sjednocené do podobného zápisu
- **Znovupoužitelnost:** jednotlivé operace lze snadno kombinovat
- **Moderní styl:** LINQ je běžná součást současného C#

---

## Třída `Student`

Projekt pracuje s vlastní třídou `Student`:

```csharp
public class Student
{
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public string Trida { get; set; }
    public string Bydliste { get; set; }

    public override string ToString()
    {
        return this.Jmeno + " " + this.Prijmeni + "(" + this.Trida + " | " + this.Bydliste + ")";
    }
}
```

**Klíčové prvky:**
- Každý student má jméno, příjmení, třídu a bydliště
- Přepsaná metoda `ToString()` usnadňuje výpis objektu do konzole

---

## Ukázky LINQ v projektu

Program používá seznam studentů vytvořený pomocnou metodou `VytvorStudenty()`. Nad tímto seznamem jsou ukázány základní LINQ operace.

### 1) Kopie celé kolekce

```csharp
List<Student> vsichniStudenti = students.ToList();
```

Tento zápis vytvoří nový seznam se stejnými prvky.

---

### 2) Filtrování pomocí `Where()`

```csharp
List<Student> studentiZLiberce = students
    .Where(student => student.Bydliste == "Liberec")
    .ToList();
```

**Co se děje:**
- `Where()` vybere jen prvky, které splní podmínku
- podmínka je zde: student bydlí v Liberci
- `ToList()` převede výsledek zpět na `List<Student>`

---

### 3) Řazení pomocí `OrderBy()`

```csharp
List<Student> serazeniPodlePrijmeni = students
    .OrderBy(student => student.Prijmeni)
    .ToList();
```

Výsledkem je seznam studentů seřazený vzestupně podle příjmení.

---

### 4) Vícekriteriální řazení

```csharp
List<Student> serazeniSestupne = students
    .OrderByDescending(student => student.Prijmeni)
    .ThenBy(student => student.Jmeno)
    .ToList();
```

**Význam:**
- `OrderByDescending()` řadí sestupně podle příjmení
- `ThenBy()` určuje další pravidlo při shodě příjmení

---

### 5) Omezení počtu výsledků pomocí `Take()`

```csharp
List<Student> prvnichPetStudentu = students
    .OrderBy(student => student.Prijmeni)
    .Take(5)
    .ToList();
```

Tento dotaz nejdříve studenty seřadí a potom vezme prvních 5 položek.

---

### 6) Seskupení pomocí `GroupBy()`

```csharp
foreach (var skupina in students.GroupBy(student => student.Trida))
{
    Console.WriteLine($"{skupina.Key}: {skupina.Count()}");
}
```

**Co se děje:**
- `GroupBy()` rozdělí studenty do skupin podle třídy
- `skupina.Key` obsahuje název třídy
- `skupina.Count()` vrací počet studentů v dané skupině

---

## Nejčastější LINQ metody v tomto projektu

| Metoda | Význam |
|--------|--------|
| `Where()` | filtruje prvky podle podmínky |
| `OrderBy()` | řadí vzestupně |
| `OrderByDescending()` | řadí sestupně |
| `ThenBy()` | doplní další pravidlo řazení |
| `Take()` | vezme prvních N prvků |
| `GroupBy()` | rozdělí data do skupin |
| `ToList()` | převede výsledek na `List<T>` |

---

## Lambda výrazy v LINQ

Většina LINQ metod v ukázce používá lambda výraz.

```csharp
student => student.Bydliste == "Liberec"
```

**Jak tento zápis číst:**
- vlevo od `=>` je parametr
- vpravo je podmínka nebo výraz, který se má vyhodnotit

---

## Kdy LINQ použít

- Když potřebujete filtrovat kolekci podle podmínky
- Když chcete data řadit podle jedné nebo více vlastností
- Když potřebujete získat jen část výsledků
- Když chcete data seskupit a dál s nimi pracovat

**Příklad porovnání:**

```csharp
// Ruční filtrování bez LINQ
List<Student> vysledek = new List<Student>();
foreach (Student student in students)
{
    if (student.Bydliste == "Liberec")
    {
        vysledek.Add(student);
    }
}

// Stejný výsledek pomocí LINQ
List<Student> vysledekLinq = students
    .Where(student => student.Bydliste == "Liberec")
    .ToList();
```

LINQ bývá kratší, přehlednější a lépe se kombinuje s dalšími operacemi.