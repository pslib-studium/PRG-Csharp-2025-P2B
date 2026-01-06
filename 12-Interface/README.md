# Interface v C#

Tento projekt demonstruje polymorfismus přes rozhraní na jednoduchém scénáři čtení knih a časopisů.


- Rozhraní `IReadable` reprezentuje "něco, co lze číst" (metoda `Read()`).
- Rozhraní `IMedium` nese základní metadata (obsah a počet stran).
- `Book` a `Magazine` implementují obě rozhraní, ale každé má vlastní detaily.
- `Reader` přijímá jen `IReadable` a neřeší, zda čte knihu nebo časopis.

## Co je interface
- Definuje **smlouvu**: seznam členů, které musí implementující typ poskytnout.
- Nemá vlastní stav ani implementaci .
- Třída může implementovat více rozhraní → skládáme chování bez dědění.


```csharp
public interface IReadable
{
    string Read();
}

public interface IMedium
{
    string Content { get; }
    int Page { get; }
}
```

## Třídy v projektu

### Book
- Implementuje `IMedium`, `IReadable` a `IEquatable<Book>` (porovnání obsahu).
- Počet stran se hrubě odhaduje podle délky textu (`Content.Length / 1800`).
- `Read()` vrací celý text knihy.

```csharp
public class Book : IMedium, IReadable, IEquatable<Book>
{
    public string Name { get; set; }
    public string Content { get; set; }
    public int Page => Content.Length / 1800;

    public string Read() => Content;
    public bool Equals(Book? other) => other is not null &&
        Content == other.Content && Name == other.Name;
}
```

### Magazine
- Také `IMedium` + `IReadable`, ale počet stran se nastavuje při vytvoření.
- `Read()` vrací text článku.

```csharp
public class Magazine : IMedium, IReadable
{
    public string Content { get; set; }
    public int Page { get; set; }

    public string Read() => Content;
}
```

### Reader
- Metoda `Reading(IReadable readable)` ukazuje polymorfismus přes rozhraní: stačí mu smlouva `Read()`.

```csharp
internal class Reader
{
    public string Name { get; set; }
    public void Reading(IReadable readable)
    {
        Console.WriteLine($"{Name} čte: " + readable.Read());
    }
}
```

## Polymorfní volání v `Program`

```csharp
Reader tonda = new Reader("Antonín");

Book babicka = new Book("Babička", "Něco o nějaké staré paní");
Book lotr = new Book("Pán Prstenů", "Něco o prstenu");
Magazine blesk = new Magazine("Další skandál", 30);

// Reader pracuje s jakýmkoli IReadable (kniha, časopis, ...)
tonda.Reading(blesk);
tonda.Reading(lotr);
tonda.Reading(babicka);
```

**Co se stane:**
- `Reader` vidí jen `IReadable`, takže volá vždy `Read()` správné implementace.
- Typ konkrétního objektu (`Book` vs `Magazine`) se vyhodnotí až za běhu → polymorfismus.

## Kdy použít interface
- Když potřebujete **smlouvu** pro různé, nesouvisející typy (např. kniha, magazín, e-book, podcast s přepisem).
- Když chcete **kompozici chování** bez omezení jednou dědickou větví (třída může implementovat více rozhraní, ale dědit jen z jedné třídy).
- Když chcete umožnit snadné **testování** – můžete předat mock/fake implementaci rozhraní.

## Porovnání: dědičnost vs. interface
- **Dědičnost**: sdílí kód i stav ("je to" vztah), 1 základní třída.
- **Interface**: sdílí jen smlouvu ("umí" vztah), lze implementovat více najednou.

## Běžné .NET interface (často uvidíte)
- `IComparable<T>` – definuje pořadí (vrací záporné/nula/kladné; díky tomu funguje řazení, operace < a > se typicky opírají o CompareTo).
- `IEquatable<T>` – efektivní test rovnosti pro `==` / `!=` a kolekce (např. HashSet); vyhýbá se boxingu u hodnotových typů.
- `IEnumerable<T>` – kolekce, kterou lze projít pomocí `foreach`; vrací `IEnumerator<T>`.
- `IEnumerator<T>` – iterátor, který umí `MoveNext()` a `Current`; `foreach` ho používá interně.
- `IDisposable` – umožňuje explicitně uvolnit zdroje (`using` pattern), hodí se pro streamy, DB spojení, handle na soubory.