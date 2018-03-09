using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class UI
    {

       
        public static void UnityFigures(Figure2D a, Figure2D b)
        {
            int k = Math.Abs(a.X - b.X);
            int z = Math.Abs(a.Y - b.Y);
            b.MovePoint(k, z);

            a.Show();
            b.Show();
        }

        /// <summary>
        //// перемещает фигуру а внутрь фигуры б
        /// </summary>
        /// <param name = "a" ></ param >
        /// < param name="b"></param>
        public static void UnityFigures(Circle a, Rectangle b)
        {
            int x = b.X + b.Width / 2;
            int y = b.Y + b.Height / 2;

            // положительный сдвиг перемещает фигуры вправо и вниз
            int k = Math.Abs(a.X - x);
            int z = Math.Abs(a.Y - y);

            // учтем взаимное расположение фигур, чтобы правильно определить сдвиг
            if (x < a.X)
            {
                k = -k;
            }
            if (y < a.Y)
            {
                z = -z;
            }

            a.MovePoint(k, z);
            a.Show();
            b.Show();
        }

        // вывод заголовкa
        public static void PrintHeader(Figure2D a)
        {
            Console.WriteLine(Environment.NewLine + a.GetFigureName());
        }

        public static void PrintUnityFigures(Figure2D a, Figure2D b)
        {
            Console.WriteLine(Environment.NewLine + "Unity figures - {0}, {1}", a.GetFigureName(), b.GetFigureName());
           
        }

        public static void PrintHeaderMove(Figure2D a)
        {
            Console.WriteLine(Environment.NewLine + "Mooving figure - {0}", a.GetFigureName());
        }

        public static void PrintHeaderMoveTo(Figure2D a)
        {
            Console.WriteLine(Environment.NewLine + "Move figure to - {0}", a.GetFigureName());
        }

        public static void PrintHeaderScal(Figure2D a)
        {
            Console.WriteLine(Environment.NewLine + "Figure scaling - {0}", a.GetFigureName());
        }

        public static void PrintHeaderPicture(Picture a)
        {
            Console.WriteLine(Environment.NewLine + "Picture:");
            for (int i = 0; i < a.CountFiguresReal; i++)
            {
                Console.Write("{0} ", a[i].GetFigureName());
                
            }
        }
    }
}
