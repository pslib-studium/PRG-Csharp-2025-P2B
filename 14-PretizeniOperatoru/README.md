# Přetížení operátorů v C#

Tento projekt demonstruje, jak v C# přetěžovat aritmetické operátory pro vlastní typy. V našem příkladu pracujeme s dvojrozměrným vektorem `Vector2D` a ukazujeme přirozenou syntaxi pro sčítání, odčítání a násobení skalárem.

## Co je přetížení operátorů?
- Umožní použít operátory (`+`, `-`, `*`, `==`, atd.) na vlastní třídy/struktury.
- Zlepšuje čitelnost a vyjadřovací sílu kódu (např. `v1 + v2` místo `v1.Add(v2)`).
- Musí být statické metody deklarované s klíčovým slovem `operator`.
- Mělo by zachovávat očekávanou matematickou logiku a být bezpečné (validace argumentů, immutability, atd.).

---

## Třída Vector2D

### Klíčové prvky
```csharp
public sealed class Vector2D
{
    public double X { get; }
    public double Y { get; }

    public Vector2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    // součet dvou vektorů
    public static Vector2D operator +(Vector2D left, Vector2D right) { ... }

    // rozdíl dvou vektorů
    public static Vector2D operator -(Vector2D left, Vector2D right) { ... }

    // násobení vektoru skalárem
    public static Vector2D operator *(Vector2D vector, double scalar) { ... }

    public override string ToString() => $"({X}, {Y})";
}
```

**Proč takhle?**
- `sealed` zabraňuje dědění (třída je finální) a drží chování uzavřené.
- Vlastnosti jsou jen pro čtení (`get;`), takže instance jsou neměnné (immutabilní).
- Operátory vracejí **novou instanci** místo úprav původních hodnot.
- Argumenty jsou validovány (kontrola `null`).

### Přetížené operátory

| Operátor | Signatura | Význam |
|----------|-----------|--------|
| `+` | `Vector2D operator +(Vector2D left, Vector2D right)` | Sčítá souřadnice `X` a `Y` | 
| `-` | `Vector2D operator -(Vector2D left, Vector2D right)` | Odečítá souřadnice `X` a `Y` |
| `*` | `Vector2D operator *(Vector2D vector, double scalar)` | Násobí obě souřadnice zadaným skalárem |

---

## Program.cs – ukázka použití
```csharp
Vector2D v1 = new Vector2D(3, 4);
Vector2D v2 = new Vector2D(-1, 2);

Vector2D sum = v1 + v2;          // (2, 6)
Vector2D difference = v1 - v2;   // (4, 2)
Vector2D scaled = v1 * 2;        // (6, 8)

Console.WriteLine(sum);        // "(2, 6)"
Console.WriteLine(difference); // "(4, 2)"
Console.WriteLine(scaled);     // "(6, 8)"
```
