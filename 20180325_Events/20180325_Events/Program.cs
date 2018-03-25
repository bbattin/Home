using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = new int[] { 5, 9, 2, 8, 4, 1 };
            
            PrintArray(items);
            Sorter p = new Sorter();

            p.Sort(items);
            PrintArray(items);

            Console.ReadKey();

        }

        private static void PrintArray(int[] items)
        {
            Console.WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(items[i]);
            }
        }
    }
}
