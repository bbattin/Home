using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180315_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a*x*x + b*x + c = 0");
            double a = GetNumberByUser();
            double b = GetNumberByUser();
            double c = GetNumberByUser();

            SquareEquationSolver result = new SquareEquationSolver(a, b, c);
            result.Calculate();
            Console.WriteLine("D = {0}, x1 = {1}, x2 = {2}", result.D, result.Root1, result.Root2);

            Console.ReadKey();
        }

        private static double GetNumberByUser()
        {
            Console.WriteLine("Enter number = ");
            double a = double.Parse(Console.ReadLine());
            return a;
        }
    }
}
