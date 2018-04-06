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
            int[] items = GetRandomArray(300);
            PrintArray(items);
            int[] itemsRep = new int[300];
            Array.Copy(items, itemsRep, items.Length);

            BubbleSort a = new BubbleSort();
            SortedAndReport(items, a);
            
            InsertionSort b = new InsertionSort();
            Array.Copy(itemsRep, items, items.Length);
            SortedAndReport(items, b);

            MergeSort c = new MergeSort();
            Array.Copy(itemsRep, items, items.Length);
            SortedAndReport(items, c);

            SortByChoice d = new SortByChoice();
            Array.Copy(itemsRep, items, items.Length);
            SortedAndReport(items, d);

            QuickSort e = new QuickSort();
            Array.Copy(itemsRep, items, items.Length);
            SortedAndReport(items, e);

            Console.ReadKey();

        }

        private static void SortedAndReport(int[] items, Sorter a)
        {
            PrintHeader(a);
            Analizer suscr = new Analizer(a);
            a.Sort(items);
            PrintArray(items);
            suscr.Report();
        }

        private static void PrintHeader(Sorter a)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(a);
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
                items[i] = rand.Next(0, 100);
            }
            return items;
        }

    }
}
