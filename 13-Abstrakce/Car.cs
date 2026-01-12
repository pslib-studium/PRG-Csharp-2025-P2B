namespace Abstrakce
{
   
    public class Car : Vehicle
    {
       
        public string Spz { get; set; }
               
        public float MaxSpeed { get; set; }

      
        public Car(string spz, float maxSpeed, string color)
        {
            this.Spz = spz;
            MaxSpeed = maxSpeed;
            Color = color;
            Capacity = 5;
        }

       
        public override void Move()
        {
            Console.WriteLine($" Auto s registrační značkou '{Spz}' se pohybuje maximální rychlostí {MaxSpeed} km/h.");
        }

       
        public string GetDescription()
        {
            return $"Osobní automobil {Spz} ({Color})";
        }

       
    }
}
