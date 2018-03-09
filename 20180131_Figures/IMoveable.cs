using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    interface IMoveable
    {
        /// <summary>
        /// изменение координат точки
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        void MovePoint(int dx, int dy);

        /// <summary>
        /// перемещение фигуры в нужную точку
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void MoveTo(int x, int y);

        /// <summary>
        /// движение фигуры по x
        /// </summary>
        /// <param name="a"></param>
        void MovingByX(int longMove);

        /// <summary>
        /// движение фигуры по x
        /// </summary>
        /// <param name="a"></param>
        void MovingByY(int longMove);
    }
}
