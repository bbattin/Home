using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
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
            p.Started += Start;
            p.Finished += Finish;

            CompareCounter = 0;
            MovedCounter = 0;
            StopWatch = new Stopwatch();
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

            TimeSpan ts = StopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000000000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("RunTime " + elapsedTime);
        }

        public void Start(object sender, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Start");
            StopWatch.Start();
        }

        public void Finish(object sender, EventArgs args)
        {
            StopWatch.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Finish");
        }

        //public void GetRunTime()
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();
        //    stopWatch.Stop();
        //    // Get the elapsed time as a TimeSpan value.
        //    TimeSpan ts = stopWatch.Elapsed;

        //    // Format and display the TimeSpan value.
        //    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000000000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine("RunTime " + elapsedTime);
            
        //}

        //public void OnNextCompare2(object sender, CompareEventArgs args)
        //{
        //    Console.ForegroundColor = ConsoleColor.Magenta;
        //    Console.WriteLine("Analizer.OnNextCompare2(): args.FirstNumber = {0}, args.SecondNumber = {1}", args.FirstNumber, args.SecondNumber);
        //}

        private int CompareCounter { get ; set ; }
        private int MovedCounter { get ; set ; }
        private Stopwatch StopWatch { get ; set ; }
        
    }
}
