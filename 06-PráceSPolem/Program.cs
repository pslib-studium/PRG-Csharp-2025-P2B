// =========================================================
// Práce s poli v C#
// =========================================================


// 1. Reference na stejné pole
int[] arr1 = { 1, 2, 3, 4, 5 };
int[] arr2 = arr1;        // arr2 odkazuje na stejné pole jako arr1
arr2[2] = 100;
Console.WriteLine("Hodnota na indexu 2 v arr1: " + arr1[2]); // Výstup: 100

// 2. Vytvoření kopie pole
int[] a = { 5, 6, 7, 8, 9 };
int[] b = (int[])a.Clone();  // vytvoření samostatné kopie pole
b[2] = 100;
Console.WriteLine("Hodnota na indexu 2 v a: " + a[2]);      // Výstup: 7

// 3. Řazení a manipulace s polem
int[] numbers2 = { 3, 1, 6, 2, 4 };
Array.Sort(numbers2);          // řazení vzestupně
Array.Reverse(numbers2);       // otočení pořadí prvků

Console.WriteLine("Obsahuje pole hodnotu 6? " + numbers2.Contains(6));

int[] emptyArr = new int[5];
Array.Fill(emptyArr, 1);       // naplnění pole hodnotou 1

// 4. Dvourozměrné pole 
int[,] map = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
Console.WriteLine("Výpis hodnot matice:");
foreach (int x in map)
{
    Console.Write(x);
}

Console.WriteLine(" Počet dimenzí matice: " + map.Rank);


// 5. Zubaté pole (jagged array)
int[][] jArray =
[
    [1, 3, 5, 7, 9],
    [0, 2, 4, 6],
    [11, 22],
];

jArray[0][1] = 77;  // změna hodnoty

Console.WriteLine("Výpis hodnot zubatého pole:");
foreach (int[] row in jArray)
{
    foreach (int value in row)
    {
        Console.Write(value + " ");
    }
}
Console.WriteLine();