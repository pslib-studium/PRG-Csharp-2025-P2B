using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Reader
    {
        public string Name { get; set; }

        public Reader(string name) {
        
            this.Name = name;
        }

        public void Reading(IReadable readable) {
            // Funguje s libovolnou implementací IReadable (kniha, časopis, ...)
            Console.WriteLine($"{Name} čte: " + readable.Read());
        }
    }
}
