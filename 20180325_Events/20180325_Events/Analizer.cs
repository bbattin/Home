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
        }

        public void OnNextCompare(object sender, CompareEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Analizer.OnNextCompare(): args.FirstNumber = {0}, args.SecondNumber = {1}", args.FirstNumber, args.SecondNumber);
        }

        public void OnNextMoved(object sender, MovedEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Analizer.OnNextMoved(): args.IndexFrom = {0}, args.IndexTo = {1}", args.IndexFrom, args.IndexTo);
        }

        //public void OnNextCompare2(object sender, CompareEventArgs args)
        //{
        //    Console.ForegroundColor = ConsoleColor.Magenta;
        //    Console.WriteLine("Analizer.OnNextCompare2(): args.FirstNumber = {0}, args.SecondNumber = {1}", args.FirstNumber, args.SecondNumber);
        //}
    }
}
