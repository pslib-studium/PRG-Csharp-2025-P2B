using _16_Generika;

// Použití generické třídy Box
Box<int> intBox = new Box<int>(5);
intBox.Store(42);
int number = intBox.GetItem(); // number = 42
Console.WriteLine(number);

Scitac<int> intScitac = new Scitac<int>(5); // Pro celá čísla (int)
Console.WriteLine(intScitac.secti(3));  // Vypíše: 8


Scitac<double> doubleScitac = new Scitac<double>(5.5); // Pro desetinná čísla (double)
Console.WriteLine(doubleScitac.secti(3.7));  // Vypíše: 9.2

// Vytvoření páru string-int
var numberPair = new Pair<string, int>("Věk", 25);
Console.WriteLine(numberPair);  // Vypíše: Key: Věk, Value: 25

// Vytvoření páru int-string
var textPair = new Pair<int, string>(1, "První");
Console.WriteLine(textPair);    // Vypíše: Key: 1, Value: První

Printer.Print<int>(10);
Printer.Print<string>("Ahoj");