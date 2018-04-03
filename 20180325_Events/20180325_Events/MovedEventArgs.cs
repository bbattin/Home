using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class MovedAndCompareEventArgs : EventArgs
    {
        public MovedAndCompareEventArgs(int i, int j)
        {
            IndexFrom = i;
            IndexTo = j;
        }

        // данные, описывающие событие
        public int IndexFrom { get; private set; } // индекс изначального положения элемента
        public int IndexTo { get; private set; }   // индекс нового положения элемента
    }
    
}
