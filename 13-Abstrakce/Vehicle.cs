namespace Abstrakce
{
    /// <summary>
    /// Abstraktní třída vozidla, která definuje společný interface pro všechna vozidla.
    /// Demonstruje použití abstraktní metody a polymorfismu.
    /// </summary>
    public abstract class Vehicle
    {
        public string Color { get; set; } = string.Empty;

        public int Capacity { get; set; }

     
        public abstract void Move();

       
        public void DisplayInfo()
        {
            Console.WriteLine($"Vozidlo má barvu: {Color}");
            Console.WriteLine($"Kapacita: {Capacity} míst");
        }       
      
    }
}
