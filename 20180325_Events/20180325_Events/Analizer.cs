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
            p.Moved += OnNextMoved;
            p.Started += Start;
            p.Finished += Finish;

            CompareCounter = 0;
            MovedCounter = 0;
            StopWatch = new Stopwatch();
        }

        public void OnNextCompare(object sender, MovedAndCompareEventArgs args)
        {
            CompareCounter++;
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            ////Console.Write(".");
            //Console.WriteLine("Compare: first number - {0}, second number = {1}", args.IndexFrom, args.IndexTo);
        }

        public void OnNextMoved(object sender, MovedAndCompareEventArgs args)
        {
            MovedCounter++;
            //Console.ForegroundColor = ConsoleColor.Gray;
            ////Console.Write(".");
            //Console.WriteLine("Moved: index from = {0}, index to = {1}", args.IndexFrom, args.IndexTo);
        }

        public void Report()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Report: count compare - {0}, moved - {1}", CompareCounter, MovedCounter);

            TimeSpan ts = StopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("RunTime " + elapsedTime);
        }

        public void Start(object sender, StartedFinishedEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Start");
            Console.WriteLine("Date now {0}", args.CreatedDate);
            StopWatch.Start();
        }

        public void Finish(object sender, StartedFinishedEventArgs args)
        {
            StopWatch.Stop();
            args.FinishDate = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Finish");
            Console.WriteLine("Date now {0}", args.FinishDate);
        }

        private int CompareCounter { get ; set ; }
        private int MovedCounter { get ; set ; }
        private Stopwatch StopWatch { get ; set ; }
        
    }
}
