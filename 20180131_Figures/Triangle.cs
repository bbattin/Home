using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Triangle : Figure2D, IResizable
    {
        protected int _width = 10;
        protected int _height = 10;

        /// <summary>
        /// полный конструктор, задает начальную координату, ширину высоту и цвет прямоугольника
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        public Triangle(int x, int y, int side, ConsoleColor color = ConsoleColor.Cyan)
            : base(x, y, color)
        {
            _width = side;
            _height = side;

            
        }

        // конструктор копирования
        public Triangle(Triangle source)
            : base(source)
        {

            _width = source.Width;
            _height = source.Height;
        }

        /// <summary>
        /// конструктор по умолчанию создает треугольник со сторонами 20х20
        /// </summary>
        public Triangle() : this(5, 5, 20)
        {

        }

        public int Width
        {
            get
            {
                return _width;
            }

        }

        public int Height
        {
            get
            {
                return _height;
            }

        }


        // создаем масив точек сторон
        protected override Point[] Build()
        {
            Point[] points = new Point[0];
            Point p;
            for (int i = 0; i < _width; i++)
            {

                // нижняя горизонтальная сторона
                p = new Point(_x + i, _y + _height, _color);
                AddPointInArray(ref points, p);
            }

            for (int j = _height; j > 0; j--)
            {
                // левая веритикальная сторона
                p = new Point(_x, _y + j, _color);
                AddPointInArray(ref points, p);
                // правая соединяющая  сторона
                p = new Point(_x + j, _y + j, _color);
                AddPointInArray(ref points, p);
            }
            return points;
        }



        /// <summary>
        /// масштабирование фигуры
        /// </summary>
        /// <param name="procent">число в процентах, на которое нужно увеличить (если с минусом, то уменьшить)</param>
        public void Scale(int procent)
        {

            _width = _width + _width / 100 * procent;
            _height = _width + _height / 100 * procent;

        }

        public override string GetFigureName()
        {
            return "Triangle";
        }
    }
}
