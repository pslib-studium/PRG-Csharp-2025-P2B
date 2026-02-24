using _16_Kolekce;
// Seznam - kolekce, která umožňuje ukládat prvky v určitém pořadí
List<int> list = new List<int> { 1, 8, 3, 7 };
list.Sort(); // seřadí prvky v seznamu
Console.WriteLine("List<int> po seřazení: " + string.Join(", ", list));

Student x = new Student("Jiří", "Novák");
List<Student> students = new List<Student>
{
    new Student("Jan", "Novák"),
    new Student("Jana", "Svobodová")
};

Console.WriteLine();
Console.WriteLine("List<Student>:");
foreach (var student in students)
{
    Console.WriteLine(student);
}
students.Add(new Student("David", "Němec"));
students.Add(x);
students.Remove(x);
students.Clear(); // odstraní všechny prvky ze seznamu


//Slovník - kolekce klíč-hodnota
Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>
{
    { "Jan", new Student("Jan", "Novák") },
    { "Jana", new Student("Jana", "Svobodová") }
};
studentDictionary.Add("David", new Student("David", "Němec"));
Console.WriteLine();
Console.WriteLine("Dictionary<string, Student>:");
foreach (var item in studentDictionary)
{
    var key = item.Key;
    var value = item.Value;
    Console.WriteLine($"{key}: {value}");
}
if (studentDictionary.ContainsKey("David"))
    Console.WriteLine("David je ve slovníku");
if (studentDictionary.ContainsValue(x))
    Console.WriteLine("Jiří Novák je ve slovníku");
else Console.WriteLine("Jiří Novák není ve slovníku");

//FIFO - první přidaný prvek je první, který se odebere
Queue<Student> messhall = new Queue<Student>();
messhall.Enqueue(new Student("Jan", "Novák"));
messhall.Enqueue(new Student("Jana", "Svobodová"));
messhall.Enqueue(new Student("David", "Němec"));
Console.WriteLine();
Console.WriteLine("Queue<Student> (FIFO):");
Console.WriteLine(messhall.Dequeue().Firstname);
Console.WriteLine(messhall.Dequeue().Firstname);
Student res;
var s = messhall.TryPeek(out res);
if (s) Console.WriteLine(res.Firstname);
else Console.WriteLine("Fronta je prázdná");

//LIFO - poslední přidaný prvek je první, který se odebere
Stack<Student> stack = new Stack<Student>();
stack.Push(new Student("Jan", "Novák"));
stack.Push(new Student("Jana", "Svobodová"));
Console.WriteLine();
Console.WriteLine("Stack<Student> (LIFO):");
Console.WriteLine(stack.Pop().Firstname);
var s2 = stack.TryPeek(out res);
if (s2) Console.WriteLine(res.Firstname);
else Console.WriteLine("Zásobník je prázdný");

//HashSet - množina, která neumožňuje duplicitní prvky
HashSet<Student> set = new HashSet<Student>();
set.Add(new Student("Jan", "Novák"));
set.Add(new Student("Jana", "Svobodová"));
set.Add(x);
set.Add(x);
Console.WriteLine();
Console.WriteLine("HashSet<Student>:");
foreach (var student in set)
{
    Console.WriteLine(student);
}

