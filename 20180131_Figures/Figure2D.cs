using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    abstract class Figure2D : IMoveable/*, ICloneable*/
    {
        protected int _x = 10;
        protected int _y = 10;
        protected ConsoleColor _color = ConsoleColor.White;

        // сифвол рисования границ фигуры
        private const string LineSymbol = "*";

        public Figure2D(int x, int y, ConsoleColor color)
        {
            _x = x;
            _y = y;
            _color = color;
        }

        // конструктор копирования
        public Figure2D(Figure2D source)
            : this(source._x, source._y, source._color)
        {

        }



        #region PROPERTIES

        public int X
        {
            get
            {
                return _x;
            }
            
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        #endregion

        //public abstract object Clone();
        

        /// <summary>
        /// для создания массива точек более сложных фигур
        /// </summary>
        /// <returns></returns>
        protected abstract Point[] Build();

        /// <summary>
        /// добаление точки в массив точек для отображения
        /// </summary>
        /// <param name="points"></param>
        /// <param name="p"></param>
        protected void AddPointInArray(ref Point[] points, Point p)
        {
            Array.Resize(ref points, points.Length + 1);
            points[points.Length - 1] = p;

        }


        /// <summary>
        /// изменение координат точки
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void MovePoint(int dx, int dy)
        {
            _x += dx;
            _y += dy;
        }

        public void MoveTo(int x, int y)
        {
            Hide();
            _x = x;
            _y = y;

            Show();

        }

        public void MovingByX(int longMove)
        {
            Show();
            for (int i = 0; i < longMove; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Hide();
                MovePoint(1, 0);
                Show();
            }
        }

        public void MovingByY(int longMove)
        {
            Show();
            for (int i = 0; i < longMove; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Hide();
                MovePoint(0, 1);
                Show();
            }
        }

        /// <summary>
        /// для получения имени фигуры
        /// </summary>
        /// <returns></returns>
        public abstract string GetFigureName();

        
       
        /// <summary>
        /// отображения массива точек
        /// </summary>
        /// <param name="clear"></param>
        public virtual void Show(bool clear = false)
        {
            Point[] points = Build();
            int oldX = Console.CursorLeft;
            int oldY = Console.CursorTop;

            for (int i = 0; i < points.Length; i++)
            {
                if (clear)
                {
                    Console.ForegroundColor = Console.BackgroundColor;
                }
                else
                {
                    Console.ForegroundColor = points[i].Color;
                }

                int conX = points[i].X;
                int conY = points[i].Y;

                // консольные координаты должны быть неотрицательными
                if (points[i].X < 0)
                {
                    conX = 0;
                }
                if (points[i].Y < 0)
                {
                    conY = 0;
                }

                Console.SetCursorPosition(conX, conY);


                Console.Write(LineSymbol);


            }

            Console.SetCursorPosition(oldX, oldY);

        }

        
       

        /// <summary>
        /// скрытие массива точек
        /// </summary>
        public void Hide()
        {
            Show(true);
        }

       
    }
}
