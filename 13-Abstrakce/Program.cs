using Abstrakce;

Vehicle[] vehicles = 
{
    new Car("4A5 4581", 120, "modré"),
    new Bus(45, "zelené"),
    new Bus(50, "červené")
};

int carCount = 0;
foreach (var vehicle in vehicles)
{
  
    if (vehicle is Car car)
    {
        carCount++;
        Console.WriteLine($" Auto #{carCount}: {car.GetDescription()}");
        car.Move();
    }
   
}

Console.WriteLine($"\n Celkem aut: {carCount}");


