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
            int a = GetNumberByUser();
            int b = GetNumberByUser();
            int c = GetNumberByUser();

            SquareEquationSolver result = new SquareEquationSolver(a, b, c);
            result.Calculate();
            Console.WriteLine("D = {0}, x1 = {1}, x2 = {2}", result.D, result.Root1, result.Root2);

            Console.ReadKey();
        }

        private static int GetNumberByUser()
        {
            Console.WriteLine("Enter number = ");
            int a = int.Parse(Console.ReadLine());
            return a;
        }
    }
}
