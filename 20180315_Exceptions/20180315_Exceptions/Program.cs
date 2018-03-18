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
            Console.WriteLine("Решение квадратного уравнения: a*x*x + b*x + c = 0, где а не равно 0. Введите a, b, c:");
            double a = GetNumberByUser();
            double b = GetNumberByUser();
            double c = GetNumberByUser();

            try
            {
                SquareEquationSolver result = Create(a, b, c);
                result.Calculate();
                Console.WriteLine("D = {0}, x1 = {1}, x2 = {2}", result.D, result.Root1, result.Root2);
            }
            catch (EquationSolverException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadKey();
        }

        private static SquareEquationSolver Create(double a, double b, double c)
        {
            SquareEquationSolver obj;

            try
            {
                obj = new SquareEquationSolver(a, b, c);
            }
            catch (EquationSolverException ex)
            {
                Console.WriteLine(ex.Message);
                obj = new SquareEquationSolver(1, b, c);
            }
            return obj;
        }

        private static double GetNumberByUser()
        {
            Console.WriteLine("Enter number = ");
            double a = double.Parse(Console.ReadLine());
            return a;
        }
    }
}
