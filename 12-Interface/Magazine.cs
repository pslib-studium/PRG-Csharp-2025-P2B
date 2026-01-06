using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Magazine : IMedium, IReadable
    {
        public string Content {  get; set; }

        public int Page { get; set; }

        public Magazine(string content, int page) { 
        
            this.Content = content;
            this.Page = page;
        
        }
        public string Read()
        {
           return Content;
        }
    }
}
