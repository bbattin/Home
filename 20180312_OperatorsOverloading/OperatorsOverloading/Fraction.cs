using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsOverloading
{
    class Fraction
    {
        private int _numerator;
        private int _denominator;
        

        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
            
        }

      

        #region Арифметические операции

        public static Fraction operator +(Fraction a, Fraction b)
        {

            return GetSum(a, b);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * b._numerator, a._denominator * b._denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * b._denominator, a._denominator * b._numerator);
        }

        #endregion

        private static int GetCommonDenominator(int d1, int d2)
        {
            int d3;
            if ((d2 >= d1) && (d2 % d1 == 0))
            {
                d3 = d2;
            }
            else
            {
                if ((d1 > d2) && (d1 % d2 == 0))
                {
                    d3 = d1;
                }
                else
                {
                    d3 = d2 * d1;
                }
            }
                                       
            return d3;
        }

        private static Fraction GetSum(Fraction a, Fraction b)
        {
            int commonDenominator = GetCommonDenominator(a._denominator, b._denominator);
            ChangeNumerator(a, commonDenominator);
            ChangeNumerator(b, commonDenominator);
            Fraction c = new Fraction(a._numerator + b._numerator, commonDenominator);
            Reduction(c);
            return c;
        }

        private static void Reduction(Fraction a)
        {
            
        }

        private static void ChangeNumerator(Fraction a, int b)
        {
            a._numerator = a._numerator * (b / a._denominator);
           
        }

      
    }
}
