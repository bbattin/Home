using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events 
{
    class CompareAndMovedEventArgs : EventArgs
    {
        public CompareAndMovedEventArgs(int a, int b)
        {
            FirstNumber = a;
            SecondNumber = b;
        }

        // данные, описывающие событие
        public int FirstNumber { get; private set; }   // значение первого элемента, который сравниваем
        public int SecondNumber { get; private set; }  // значение второго элемента, который сравниваем
    }
}
