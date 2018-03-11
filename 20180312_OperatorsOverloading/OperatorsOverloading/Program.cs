using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(3, 4);
            Fraction b = new Fraction(3, 5);
            Fraction c = a + b;
            double e = c.ToDouble();
            Console.WriteLine(c);
            Console.WriteLine(e);
            Fraction d = new Fraction(10, 20);
            c = Fraction.Normalization(d);
            Console.WriteLine(c);
            
            Console.ReadKey();
        }
    }
}
