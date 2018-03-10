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

        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
             
        }

        #region Арифметические операции

        //public static Fraction Plus(Fraction a, Fraction b)
        //{
        //    return new Fraction(a._numerator + b._denominator);
        //}

        //public static Fraction operator +(Fraction a, Fraction b)
        //{
        //    return Plus(a, b);
        //}

       

        #endregion
    }
}
