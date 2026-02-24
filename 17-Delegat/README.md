# Delegáty v C#

Tento projekt demonstruje koncept **delegátů** v C#. Delegát je typ, který reprezentuje odkaz na metodu se stejnou signaturou. Díky tomu můžeme předávat metody jako parametry, ukládat je do proměnných a volit chování programu dynamicky.

## Co je delegát?

- Delegát je „proměnná pro metodu“.
- Může odkazovat na libovolnou metodu se stejnými parametry a návratovým typem.
- Umožňuje oddělit **co** se má provést od **kdy a kde** se to provede.
- Často se používá s lambda výrazy.

**Klíčové výhody:**
- **Flexibilita:** měníte chování předáním jiné metody
- **Znovupoužitelnost:** jedna metoda může přijímat různé operace
- **Čitelnost:** operace je explicitně předaná jako parametr
- **Moderní styl:** přirozená návaznost na `Func`, `Action`, `Predicate`

---

## Vlastní delegát `MathOp`

### Definice

```csharp
delegate double MathOp(double x, double y);
```

**Význam:**
- Delegát přijímá dvě `double` hodnoty (`x`, `y`)
- Vrací jednu `double` hodnotu
- Každá metoda s touto signaturou je použitelná přes `MathOp`

---

## Metody pro výpočet

```csharp
double Secti(double x, double y) => x + y;
double Vynasob(double x, double y) => x * y;
```

Obě metody mají stejnou signaturu jako `MathOp`, takže je lze přiřadit do stejné delegátové proměnné.

---

## 1) Delegát jako proměnná

```csharp
MathOp matematickaOperace = Secti;
double soucet = matematickaOperace(prvniCislo, druheCislo);

matematickaOperace = Vynasob;
double soucin = matematickaOperace(prvniCislo, druheCislo);
```

**Co se děje:**
- `matematickaOperace` nejdřív ukazuje na metodu `Secti`
- později se přepne na metodu `Vynasob`
- volání zůstává stejné, mění se jen konkrétní prováděná logika

---

## 2) Delegát jako parametr metody

```csharp
double Vypocitej(double x, double y, MathOp operace)
{
    return operace(x, y);
}
```

Použití:

```csharp
double vysledekMetoda = Vypocitej(prvniCislo, druheCislo, Secti);
```

**Výhoda:**
- metoda `Vypocitej` je univerzální
- neřeší, jestli sčítáte, násobíte nebo děláte jinou operaci

---

## 3) Lambda výraz místo pojmenované metody

```csharp
double vysledekLambda = Vypocitej(prvniCislo, druheCislo, (x, y) => x - y);
```

Lambda je anonymní funkce zapsaná přímo na místě použití.

**Kdy je vhodná:**
- když je operace krátká
- když ji nepotřebujete používat opakovaně

---

## 4) Předdefinovaný delegát `Func`

Místo vlastního delegátu lze použít vestavěný typ `Func`.

```csharp
Func<double, double, double> deleni = (x, y) => x / y;

double PouzijFunc(double x, double y, Func<double, double, double> operace)
{
    return operace(x, y);
}

double podil = PouzijFunc(prvniCislo, druheCislo, deleni);
```

**Jak číst `Func<double, double, double>`:**
- první `double` = 1. parametr
- druhý `double` = 2. parametr
- poslední `double` = návratová hodnota

---

## Vlastní delegát vs. `Func`

| Přístup | Kdy použít | Výhoda |
|---------|------------|--------|
| `MathOp` (vlastní delegát) | výuka, doménově srozumitelné API | název přesně popisuje účel |
| `Func<T...>` | obecné utility a kratší zápis | méně vlastních typů v projektu |




