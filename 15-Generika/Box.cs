using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Generika
{
    public class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public void Store(T item)
        {
            this.item = item;
        }

        public T GetItem()
        {
            return item;
        }
    }
}
