# Unit testy v C# (xUnit)

Tento projekt ukazuje základy psaní **unit testů** pomocí frameworku **xUnit** nad třídou kalkulačky z projektu `21-UT-Calculator`.

Cílem je ověřit, že jednotlivé metody třídy `Calculator` vrací správné výsledky a že správně reagují i na chybové stavy (např. dělení nulou).

## Co je unit test

**Unit test** je automatický test malé části aplikace (typicky jedné metody).

- Testuje jednu "jednotku" chování izolovaně
- Má jasně daný vstup a očekávaný výstup
- Měl by být rychlý, opakovatelný a srozumitelný
- Pomáhá odhalit regresi po úpravách kódu

---

## Proč unit testy používat

- **Bezpečnější změny v kódu:** po úpravě hned vidíte, co se rozbilo
- **Dokumentace chování:** testy popisují, co má metoda dělat
- **Rychlá kontrola funkčnosti:** testy lze spouštět opakovaně jedním kliknutím
- **Vyšší kvalita kódu:** testovatelný kód bývá čistší a přehlednější

---

## Testovaná třída

V tomto cvičení se testuje třída `Calculator` z projektu `21-UT-Calculator`:

- `Addition(double x, double y)`
- `Multiplication(double x, double y)`
- `Divide(double x, double y)`

U metody `Divide` je důležité otestovat i výjimku při dělení nulou.

---

## Jak ve Visual Studiu přidat testovanou třídu z jiného projektu

Aby mohl testovací projekt `21-UT-xUnit` používat `Calculator` z `21-UT-Calculator`, je potřeba přidat **Project Reference**.

### Postup (Visual Studio)

1. Otevřete solution `PRG-2025.sln`.
2. V **Solution Exploreru** najděte projekt `21-UT-xUnit`.
3. Klikněte pravým tlačítkem na `Dependencies` (nebo `References`) v projektu `21-UT-xUnit`.
4. Zvolte **Add Project Reference...**.
5. Zaškrtněte projekt `21-UT-Calculator`.
6. Potvrďte tlačítkem **OK**.
7. V testovacím souboru přidejte namespace:

```csharp
using _21_UT_Calculator;
```

Od této chvíle můžete v testech vytvářet instanci:

```csharp
Calculator calculator = new Calculator();
```

---

## Základ xUnit atributů

xUnit používá atributy pro označení testovacích metod.

### `[Fact]`

Používá se pro jeden konkrétní test bez parametrů.

```csharp
[Fact]
public void TestAdd1and1()
{
    Assert.Equal(2, calculator.Addition(1, 1));
}
```

### `[Theory]` + `[InlineData(...)]`

Používá se, když chcete stejnou testovací logiku spustit nad více vstupy.

```csharp
[Theory]
[InlineData(2, 2, 4)]
[InlineData(3, 2, 6)]
[InlineData(-1, 8, -8)]
public void TestMul(double a, double b, double expected)
{
    Assert.Equal(expected, calculator.Multiplication(a, b));
}
```

---

## Asertace a testování výjimek

Nejpoužívanější v tomto projektu:

- `Assert.Equal(expected, actual)` - porovná očekávanou a skutečnou hodnotu
- `Assert.Throws<TException>(...)` - ověří, že kód vyhodí očekávanou výjimku

Příklad testu výjimky:

```csharp
[Fact]
public void TestDivideByZero()
{
    Assert.Throws<ArgumentException>(() => calculator.Divide(2, 0));
}
```

## Jak testy spustit ve Visual Studiu

1. Otevřete **Test Explorer** (`Test > Test Explorer`).
2. Klikněte na **Run All Tests**.
3. Zkontrolujte, které testy prošly/neprošly.
4. Při chybě otevřete detail testu a opravte buď implementaci, nebo test.