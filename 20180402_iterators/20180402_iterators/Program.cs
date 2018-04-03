using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180402_iterators
{
    class Program
    {
        public static Random random = new Random();

        static void Main(string[] args)
        {

            Container c = CreateRandomContainer(20);

            foreach (object b in c)
            {
                Console.WriteLine(b);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// создает контейнер заданной длины и наполняет рандомными числами
        /// </summary>
        /// <param name="count">количество элементов в контейнере</param>
        /// <returns></returns>
        private static Container CreateRandomContainer(int count)
        {
            Container c = new Container(count);
            
            for (int i = 0; i < count; i++)
            {
                c.Add(random.Next(0, 1000));
            }
            return c;
        }

       
    }
}
