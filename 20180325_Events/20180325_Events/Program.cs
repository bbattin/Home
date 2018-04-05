using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = GetRandomArray(150);
            
            PrintArray(items);
            BubbleSort p = new BubbleSort();
                                                
            Analizer suscr = new Analizer(p);
            
            p.Sort(items);
            PrintArray(items);
            suscr.Report();

            Console.ReadKey();

        }

        private static void PrintArray(int[] items)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Array: ");
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write("{0} ", items[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static int[] GetRandomArray(int countItems)
        {
            Random rand = new Random();
            int[] items = new int[countItems];
            for (int i = 0; i < countItems; i++)
            {
                items[i] = rand.Next(0, 1000000);
            }
            return items;
        }

    }
}
