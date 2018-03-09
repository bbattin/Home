using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Rectangle : Figure2D, IResizable
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
        public Rectangle(int x, int y, int width, int height, ConsoleColor color = ConsoleColor.White) 
            : base(x, y, color)
        {
            _width = width;
            _height = height;

        }

        // конструктор копирования
        public Rectangle(Rectangle source)
            : base(source)
        {

            _width = source.Width;
            _height = source.Height;
        }

        /// <summary>
        /// конструктор по умолчанию создает прямоугольник со сторонами 9х6 линиями белого цвета
        /// </summary>
        public Rectangle() : this(5, 5, 9, 6)
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
                // верхняя горизонтальная сторона
                p = new Point(_x + i, _y, _color);
                AddPointInArray(ref points, p);

                // нижняя горизонтальная сторона
                p = new Point(_x + i, _y + _height, _color);
                AddPointInArray(ref points, p);
            }

            for (int j = 1; j < _height; j++)
            {
                // левая веритикальная сторона
                p = new Point(_x, _y + j, _color);
                AddPointInArray(ref points, p);
                // правая веритикальная  сторона
                p = new Point(_x + _width - 1, _y + j, _color);
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

            _width = Convert.ToInt32(_width + _width / 100.0 * procent);
            _height = Convert.ToInt32(_height + _height / 100.0 * procent);

        }

        public override string GetFigureName()
        {
            return "Rectangle";
        }

       
    }
}
