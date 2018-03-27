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

            Analizer suscr = new Analizer(p);
            p.BubbleSort(items);
            PrintArray(items);
            suscr.Report();

            //p.Compare += OnNextCompare;
            //p.BubbleSort(items);
            //PrintArray(items);

            Console.ReadKey();
        

        

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

        //// статический слушатель
        //public static void OnNextCompare(object sender, CompareEventArgs args)
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("static OnNextCompare(): args.FirstNumber = {0}, args.SecondNumber = {1}", args.FirstNumber, args.SecondNumber);
        //}
}
}
