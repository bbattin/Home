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
            p.Compare += OnNextCompare1;
            p.Compare += OnNextCompare2;
        }

        public void OnNextCompare1(object sender, CompareEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Analizer.OnNextCompare1(): args.FirstNumber = {0}, args.SecondNumber = {1}", args.FirstNumber, args.SecondNumber);
        }

        public void OnNextCompare2(object sender, CompareEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Analizer.OnNextCompare2(): args.FirstNumber = {0}, args.SecondNumber = {1}", args.FirstNumber, args.SecondNumber);
        }
    }
}
