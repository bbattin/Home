using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Triangle2 : Square
    {
        /// <summary>
        /// конструктор по умолчанию на основе базового класса
        /// </summary>
        public Triangle2()
            : base()
        {

            Build();
        }
        
        public Triangle2(int x, int y, int side, ConsoleColor color = ConsoleColor.DarkMagenta)
             : base(x, y, side, color)
        {


            Build();
        }

        protected override void Build()
        {
            for (int i = 0; i < _width; i++)
            {

                // нижняя горизонтальная сторона
                Add(new Point(_x + i, _y + _height, _color));
            }

            for (int j = _height; j > 0; j--)
            {
                // левая веритикальная сторона
                Add(new Point(_x, _y + j, _color));
                // правая соединяющая  сторона
                Add(new Point(_x + j, _y + j, _color));
            }
        }

        public override string GetFigureName()
        {
            return "Triangle 2";
        }
    }
}
