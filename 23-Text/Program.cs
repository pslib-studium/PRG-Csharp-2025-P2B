using System.Globalization;
using System.Text;

string text = "Ahoj";
char[] letters = new char[] { 'A', 'h', 'o', 'j'};
char[] chars = text.ToCharArray();

string text2 = new string(letters);

Console.WriteLine(text);
Console.WriteLine("Ahoj, \njak se máš?  Je to \"super\"");

Console.WriteLine(@"Ahoj,
jak se máš.
Co děláš?");

Console.WriteLine("""
    Ahoj,
    jak se máš. Je to "super"
    """);

StringBuilder sb = new StringBuilder();
sb.Append("Ahoj");
sb.AppendLine("jak se máš?");

Console.WriteLine(sb.ToString());
Console.WriteLine("----- Metody pro práci s řetězci ----");
text = "Tento program vypisuje výsledky na obrazovku";
Console.WriteLine(text.Substring(6,7)); // vypíše program
Console.WriteLine(text.IndexOf("program")); // vypíše 6
Console.WriteLine(text.Contains("výsledky")); // vypíše True, protože text obsahuje slovo výsledky
Console.WriteLine(text.Replace("vypisuje", "zobrazí")); // vypíše Tento program zobrazí výsledky na obrazovku
Console.WriteLine(text.Remove(text.IndexOf(" na obrazovku"), " na obrazovku".Length)); // vypíše Tento program výsledky 


string[] words = text.Split(' ');
foreach (var word in words)
{
    Console.WriteLine(word);
}

Console.WriteLine(text.ToLower());
Console.WriteLine(text.ToUpper());

string text3 = "   Ahoj   ";
Console.WriteLine(text3.Trim()); // vypíše Ahoj bez mezer


string formatText = "stojí to {0} {1}";
string mena = "Kč";
Console.WriteLine(string.Format(formatText,12,mena));

Console.WriteLine("------ Výpis času a datumu ----");
DateTime now = DateTime.Now;

string formattedDate = now.ToString("dd.MM.yyyy HH:mm:ss");
Console.WriteLine(formattedDate); // vypíše aktuální datum a čas ve formátu dd.MM.yyyy HH:mm:ss

string format = "Dnes je {0:dddd}, {0:dd. MMMM yyyy}";
string formatted = string.Format(format, DateTime.Now);

Console.WriteLine(now.ToString("D")); // vypíše aktuální datum ve formátu 
Console.WriteLine(now.ToString("D",CultureInfo.GetCultureInfo("en-US")));

//Odstranění diakritiky
string txt = "Šílená čivava";
string normalizedText = txt.Normalize(NormalizationForm.FormD);
StringBuilder sb2 = new StringBuilder();
foreach (var x in normalizedText)
{
    if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(x) != System.Globalization.UnicodeCategory.NonSpacingMark)
    {
        sb2.Append(x);
    }
}
Console.WriteLine(sb2.ToString().Normalize(NormalizationForm.FormC));

Console.WriteLine("---- Regulární výrazy ----");

text = "Můj email je karel@seznam.cz a můj telefon je 123 456 789 a PSČ 200 00 Praha ";

string pattern = @"\b\d{3} \d{3} \d{3}\b";
var matches = System.Text.RegularExpressions.Regex.Matches(text, pattern);
foreach (var match in matches)
{
    Console.WriteLine("telefonní číslo:" + match);
}