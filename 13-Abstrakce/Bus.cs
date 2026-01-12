namespace Abstrakce
{
    /// <summary>
    /// Konkrétní implementace vozidla - autobus.
    /// Demonstruje implementaci abstraktní třídy a validaci vlastností.
    /// </summary>
    public class Bus : Vehicle
    {
        private int _passengers = 0;
             
        public int Passengers
        {
            get { return _passengers; }
            set
            {
                if (Capacity < value)
                {
                    throw new ArgumentException($"Překročena kapacita autobusu! Maximální počet pasažérů: {Capacity}, pokus: {value}");
                }
                _passengers = value;
            }
        }

     
        public Bus(int capacity, string color)
        {
            Capacity = capacity;
            Color = color;
            _passengers = 0;
        }

     
        public override void Move()
        {
            Console.WriteLine($"Autobus jede s {Passengers}/{Capacity} pasažéry.");
        }
      
      
    }
}
