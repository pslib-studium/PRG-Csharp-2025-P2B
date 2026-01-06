using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Book : IMedium, IReadable, IEquatable<Book>    
    {
        public string Name { get; set; }

        public string Content {  get; set; }

        // Hrubý odhad počtu stran podle délky textu
        public int Page { get { return Content.Length / 1800; } }

        public Book(string name, string content) { 
            Name = name;
            Content = content;
        
        }
        public string Read()
        {
            return Content;
        }

       
        public bool Equals(Book? other)
        {
           if (other is null) return false;
           return Content == other.Content && Name == other.Name;
        }
        
       
    }
}
