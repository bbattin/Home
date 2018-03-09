using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // создание, вывод, скрытие прямоугольника конструктором по умолчанию
            Rectangle b = new Rectangle();
            UI.PrintHeader(b);
            b.Show();
            Console.ReadKey();
            b.Hide();

            // создание, вывод, перемещение и скрытие прямоугольника задаными значениями
            Rectangle b2 = new Rectangle(5, 5, 15, 10, ConsoleColor.Blue);
            b2.Show();
            Console.ReadKey();
            UI.PrintHeaderMoveTo(b2);
            b2.MoveTo(20, 10);
            Console.ReadKey();
            Console.Clear();

            // создание, вывод круга задаными значениями
            Circle a2 = new Circle(44, 12, 6);
            UI.PrintHeader(a2);
            a2.Show();
            Console.ReadKey();
            Console.Clear();

            
            // добавление и вывод фигур из контейнера;
            Picture one = new Picture(5);
            one.Add(b);
            one.Add(b2);
            one.Add(a2);
            UI.PrintHeaderPicture(one);
            one.ShowAll();
            Console.ReadKey();
            Console.Clear();

            // масштабирование всех фигур в контейнере
            one.Scale(-50);
            one.ShowAll();
            Console.ReadKey();
            Console.Clear();

            ////движение всех фигур в контейнере поочередно по x
            //one.MoveFigures(5);
            //Console.ReadKey();
            //Console.Clear();

            //// движение всех фигур в контейнере одновременно по x
            //one.MoveAllFigures(5);
            //Console.ReadKey();
            //Console.Clear();

            // перемещение всех фигур по отношению к координатам
            one.MoveAllTo(10, 10);
            Console.ReadKey();
            Console.Clear();

            //// создание, вывод, скрытие квадрата конструктором по умолчанию
            //Square c = new Square();
            //UI.PrintHeader(c);
            //UI.Show(c);
            //Console.ReadKey();
            //UI.Hide(c);

            //// создание, вывод, скрытие квадрата задаными значениями
            //Square c2 = new Square(5, 6, 20);
            //UI.PrintHeader(c2);
            //c2.Show();
            //Console.ReadKey();
            //Console.Clear();

            //// создание, вывод, скрытие круга конструктором по умолчанию
            //Circle a = new Circle();
            //UI.PrintHeader(a);
            //UI.Show(a);
            //Console.ReadKey();
            //UI.Hide(a);



            // изменение масштаба круга
            UI.PrintHeaderScal(a2);
            a2.Scale(70);
            a2.Show();
            Console.ReadKey();
            Console.Clear();

            // изменение масштаба прямоугольника
            UI.PrintHeaderScal(b2);
            b2.Scale(80);
            b2.Show();
            Console.ReadKey();
            Console.Clear();

            // создание, вывод треугольника (конструктор по умолчанию, равносторонний) 
            Triangle d = new Triangle();
            UI.PrintHeader(d);
            d.Show();
            Console.ReadKey();
            Console.Clear();
            // приводим прямоугольник в движение и после скрываем
            UI.PrintHeaderMove(d);
            d.MovingByX(10);
            Console.Clear();

            //// создание, вывод, скрытие треугольника задаными значениями
            //Triangle d2 = new Triangle(5, 3, 10);
            //UI.PrintHeader(d2);
            //UI.Show(d2);
            //Console.ReadKey();
            //Console.Clear();

            // меняем масштабы и объединяем прямоугольник и круг (круг внутри прямоугольника)   
            UI.PrintHeaderScal(b);
            b.Scale(100);
            a2.Scale(-40);
            UI.PrintUnityFigures(a2, b);
            UI.UnityFigures(a2, b);
            Console.ReadKey();
            Console.Clear();

            // пробуем объединять другие фигуры
            // треугольник и прямоугольник
            UI.PrintUnityFigures(d, b);
            UI.UnityFigures(d, b);
            Console.ReadKey();
            Console.Clear();

            //// треугольник2 и прямоугольник2
            //UI.PrintUnityFigures(d2, b2);
            //UI.UnityFigures(d2, b2);
            //Console.ReadKey();
            //Console.Clear();

            //// прямоугольник и прямоугольник2
            //UI.PrintUnityFigures(b, b2);
            //UI.UnityFigures(b, b2);
            //Console.ReadKey();
            //Console.Clear();

            //// треугольник и круг
            //UI.PrintUnityFigures(d, a);
            //UI.UnityFigures(d, a);
            //Console.ReadKey();
            //Console.Clear();

            Console.ReadKey();
        }

        
    }
}
