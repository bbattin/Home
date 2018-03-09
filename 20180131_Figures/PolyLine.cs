using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class PolyLine : Figure2D    
    {

        protected Point[] _points;

        /// <summary>
        //// конструктор устанавливает начальную координату фигуры и цвет, создает пустой массив точек из которых будет состоять фигура
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public PolyLine(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            _points = new Point[0];
        }

        public PolyLine(params Point[] points)
            : base(points[0].X, points[0].Y, points[0].Color)
        {           
            _points = (Point[])points.Clone();
        }

        public PolyLine(PolyLine source)
            : this(source._points)
        {

        }

        

        public override string GetFigureName()
        {
            return "Poly line";
        }


        protected override Point[] Build()
        {
            return null;
        }


        #region properies & indexators

        public int PointCount
        {
            get
            {
                return _points.Length;
            }
        }        

        public Point this[int index]
        {
            get 
            {
                return new Point(_points[index]);
            }
            set 
            {
                _points[index] = new Point(value);
            }
        }

        public bool this[int x, int y]
        {
            get
            {
                bool found = false;

                for (int i = 0; i < PointCount; i++)
                {
                    if ((_points[i].X == x) && (_points[i].Y == y))
                    {
                        found = true;
                    }
                }

                return found;
            }
        }

        #endregion

        #region member function

        public int GetPointCount()
        {
            return _points.Length;
        }

        public Point GetPointByPosition(int position)
        { 
            // validation !!!
            return _points[position];
        }

        public void Add(Point newPoint)
        {
            if (_points == null)
            {
                _points = new Point[0];
            }

            Array.Resize(ref _points, _points.Length + 1);
            _points[_points.Length - 1] = newPoint;
        }

        public void Delete()
        {
            Array.Resize(ref _points, _points.Length - 1);
        }

        //public new void Move(int dx, int dy)
        //{
        //    //base.Move(dx, dy);

        //    for (int i = 0; i < _points.Length; i++)
        //    {
        //        //_points[i].Move(dx, dy);

        //       // this[i].Move(dx, dy);   // обращение к индексатору, который возвращает копию точки

        //        Point pICopy = this[i];   // get copy
        //        pICopy.Move(dx, dy);
        //        this[i] = pICopy;    // set copy
        //    }
        //}

        #endregion


        
    }    
}
