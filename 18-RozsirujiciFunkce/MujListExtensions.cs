using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_RozsirujiciFunkce
{
    public static class MujListExtensions
    {
        public static int CountOdd(this List<int> ints) 
        {
            int i = 0;
            foreach (int j in ints)
            {
                if (j % 2 == 1)
                {
                    i++;
                }
            }
            return i;
        }
    }
}
