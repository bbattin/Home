using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo    
{
    class Point : Figure2D
    {
        #region CTOR's

        public Point()     // конструктор по-умолчению
            : this(1, 1)    // вызов конструктора c 2-мя параметрами
        {
        }

        // конструктор с 2-мя параметрами 
        public Point(int x, int y)
            : this(x, y, ConsoleColor.Red)    // вызов конструктора c 3-мя параметрами
        {
        }

        // конструктор с 3-мя параметрами (наиболее полная версия конструктора)
        public Point(int x, int y, ConsoleColor color)
            : base(x, y, color)    // вызов конструктора базового класса с 3-мя параметрами
        {
        }

        // конструктор копирования
        public Point(Point source)
            : this(source._x, source._y, source._color)
        {
        }

        #endregion

        ~Point()
        {
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("~Point(_x={0},_y={1},_color={2})", _x, _y, _color);               
#endif     
        }

        public override string GetFigureName()
        {
            return "Point";
        }

        protected override Point[] Build()
        {
            return null;
        }
    }

    

    // класс-обертка для доступа к точке (Point) "read only"
    class ROPoint
    {
        public ROPoint(Point p)
        {
            _p = p;
        }

        public int GetX()
        {
            // консольные координаты должны быть неотрицательными
            if (_p.X < 0)
            {
                return 0;
            }
            return _p.X;
        }

        public int GetY()
        {
            // консольные координаты должны быть неотрицательными
            if (_p.Y < 0)
            {
                return 0;
            }

            return _p.Y;
        }

        public ConsoleColor GetColor()
        {
            return _p.Color;
        }

        private Point _p;

    }
}
