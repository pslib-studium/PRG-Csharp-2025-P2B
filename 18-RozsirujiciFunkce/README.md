# Rozšiřující funkce v C#

Tento projekt demonstruje koncept **rozšiřujících funkcí (extension methods)** v C#. Rozšiřující funkce umožňují přidat nové chování existujícím typům bez úpravy jejich původního zdrojového kódu. V ukázce je přidána metoda `CountOdd()` pro `List<int>`.

## Co jsou rozšiřující funkce?

- Jsou to statické metody ve statické třídě.
- První parametr má klíčové slovo `this` a určuje typ, který se rozšiřuje.
- Volají se stejně jako běžné instance metody (`objekt.Metoda()`).
- Umožňují zpřehlednit kód a znovu použít logiku na více místech.

**Klíčové výhody:**
- **Čitelnost:** volání vypadá přirozeně (`numbers.CountOdd()`).
- **Znovupoužitelnost:** stejná logika pro více seznamů.
- **Bez zásahu do typu:** není nutné měnit `List<T>` ani dědit.
- **Organizace kódu:** pomocné operace lze sdružit do jedné utility třídy.

---

## Třída `MujListExtensions`

```csharp
public static class MujListExtensions
{
    public static int CountOdd(this List<int> ints)
    {
        int i = 0;
        foreach (int j in ints)
        {
            if (j % 2 == 1)
            {
                i++;
            }
        }
        return i;
    }
}
```

### Jak to funguje

- `public static class` je povinný základ pro extension methods.
- `this List<int> ints` říká, že metoda rozšiřuje typ `List<int>`.
- Metoda projde seznam a spočítá prvky, které splní podmínku lichosti (`j % 2 == 1`).
- Výsledkem je počet lichých čísel typu `int`.

---

## Použití v `Program.cs`

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 7, 8, 5, 9, 6, 1, 4, 8, 4 };
Console.WriteLine(numbers.CountOdd()); // volani rozsirujici funkce
```

### Co se děje při volání

1. Vytvoří se seznam `numbers`.
2. Zavolá se rozšiřující funkce `CountOdd()`.
3. Metoda vrátí počet lichých hodnot.
4. Výsledek se vypíše do konzole.

---

## Běžná pravidla pro extension methods

| Pravidlo | Význam |
|---------|--------|
| Statická třída | Rozšiřující metoda musí být ve statické třídě |
| Statická metoda | Samotná metoda musí být `static` |
| `this` u 1. parametru | Určuje rozšiřovaný typ |
| Namespace musí být dostupný | Je potřeba `using` správného jmenného prostoru |

---

## Kdy extension methods použít

- Když chcete přidat utility metodu k existujícímu typu.
- Když nechcete nebo nemůžete upravovat původní třídu.
- Když potřebujete mít kód čitelnější než volání statické helper metody.

**Příklad porovnání:**

```csharp
// Bez extension metody
int oddCount = MujListExtensions.CountOdd(numbers);

// S extension metodou
int oddCount2 = numbers.CountOdd();
```