using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Square : Rectangle
    {
        /// <summary>
        /// конструктор по умолчанию на основе базового класса
        /// </summary>
        public Square() 
            : base(5, 5, 10, 10, ConsoleColor.DarkRed)
        {
                       
        }

        public Square(int x, int y, int side, ConsoleColor color = ConsoleColor.DarkMagenta)
             : base(x, y, side, side, color)
        {
           
        }

        public override string GetFigureName()
        {
            return "Square";
        }
    }
}
