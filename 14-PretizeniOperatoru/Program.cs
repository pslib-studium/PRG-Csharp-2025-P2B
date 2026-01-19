using _14_PretizeniOperatoru;

Vector2D v1 = new Vector2D(3, 4);
Vector2D v2 = new Vector2D(-1, 2);

Console.WriteLine("Vektor v1: " + v1);
Console.WriteLine("Vektor v2: " + v2);

// Sečteme vektory
Vector2D sum = v1 + v2;
// Odečteme vektory
Vector2D difference = v1 - v2;
// Vynásobíme vektor skalárem
Vector2D scaled = v1 * 2;

Console.WriteLine("Součet (v1 + v2): " + sum);
Console.WriteLine("Rozdíl (v1 - v2): " + difference);
Console.WriteLine("Skalární násobení: " + scaled);
