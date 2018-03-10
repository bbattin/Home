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
        private double _decimalNumber;

        public Fraction(int numerator, int denominator, double decimalNumber)
        {
            _numerator = numerator;
            _denominator = denominator;
            
        }

        public Fraction(int numerator)
        {
            _numerator = numerator;
        }

        public Fraction(double decimalNumber)
        {
            _decimalNumber = decimalNumber;
        }

        #region Арифметические операции

        //public static Fraction Plus(Fraction a, Fraction b)
        //{
        //    return new Fraction(a._numerator + b._denominator);
        //}

        //public static Fraction operator +(Fraction a, Fraction b)
        //{

        //    return new Fraction(a._numerator + b._numerator, a._decimalNumber + b._decimalNumber);
        //}

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * b._numerator, a._denominator * b._denominator, a._decimalNumber * b._decimalNumber);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * b._denominator, a._denominator * b._numerator, a._decimalNumber / b._decimalNumber);
        }

        #endregion
    }
}
