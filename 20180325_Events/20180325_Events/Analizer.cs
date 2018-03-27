using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class Analizer
    {
        public Analizer(Sorter p)
        {
            p.Compare += OnNextCompare;
            //p.Compare += OnNextCompare2;
            p.Moved += OnNextMoved;
            CompareCounter = 0;
            MovedCounter = 0;

        }

        public void OnNextCompare(object sender, CompareEventArgs args)
        {
            CompareCounter++;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Compare: first number - {0}, second number = {1}", args.FirstNumber, args.SecondNumber);
        }

        public void OnNextMoved(object sender, MovedEventArgs args)
        {
            MovedCounter++;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Moved: index from = {0}, index to = {1}", args.IndexFrom, args.IndexTo);
        }

        public void Report()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Report: count compare - {0}, moved - {1}", CompareCounter, MovedCounter);
        }


        //public void OnNextCompare2(object sender, CompareEventArgs args)
        //{
        //    Console.ForegroundColor = ConsoleColor.Magenta;
        //    Console.WriteLine("Analizer.OnNextCompare2(): args.FirstNumber = {0}, args.SecondNumber = {1}", args.FirstNumber, args.SecondNumber);
        //}

        private int CompareCounter { get ; set ; }
        private int MovedCounter { get ; set ; }
    }
}
