using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Circle : Figure2D, IResizable
    {
        protected int _r = 0;

        public Circle(int x, int y, int r, ConsoleColor color = ConsoleColor.Green) 
            : base(x, y, color)
        {
            _r = r;
            
        }

        // конструктор копирования
        public Circle(Circle source)
            : base(source)
        {

            _r = source.R;
            
        }

        /// <summary>
        /// конструктор по умолчанию создает круг с радиусом 9
        /// </summary>
        public Circle() : this(12, 12, 9)
        {

        }

        public int R
        {
            get
            {
                return _r;
            }

        }

        
        // создаем масив точек
        protected override Point[] Build()
        {
            Point[] points = new Point[0];
            Point p;
            for (int x = _x - _r; x <= _x + _r; x++)
            {
                p = new Point(x, (_y - Convert.ToInt32(Math.Round(Math.Sqrt(Convert.ToDouble(_r * _r - (_x - x) * (_x - x)))))), ConsoleColor.DarkCyan);
                AddPointInArray(ref points, p);
                p = new Point(x, (_y + Convert.ToInt32(Math.Round(Math.Sqrt(Convert.ToDouble(_r * _r - (_x - x) * (_x - x)))))), ConsoleColor.Gray);
                AddPointInArray(ref points, p);

            }

            return points;
        }

        

        public override string GetFigureName()
        {
            return "Circle";
        }

        public void Scale(int procent)
        {
            _r = Convert.ToInt32(_r + _r / 100.0 * procent);
            
        }

        //public override object Clone()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
