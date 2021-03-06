﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180315_Exceptions
{
    class SquareEquationSolver
    {
        /// <summary>
        /// инициализирует эллементы квадратного уравнения (a*x*x + b*x + c = 0)
        /// </summary>
        /// <param name="a">a*x*x</param>
        /// <param name="b">b*x</param>
        /// <param name="c">c</param>
        public SquareEquationSolver(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new EquationSolverException("Ошибка: условие уравнения - a не равно 0, присвоено значение 1");
            }
            else
            {
                _a = a;
            }
            _b = b;
            _c = c;
        }

        /// <summary>
        /// получает дискриминант и два корня
        /// </summary>
        public void Calculate()
        {
            GetD();
            if (D == 0)
            {
                GetRoot1();
                Root2 = Root1;
            }
            else
            {
                GetRoot1();
                GetRoot2();
            }
            
        }

        //public byte RootCount { get => _rootCount; private set => _rootCount = value; }
        public double Root1 
        { 
            get 
            {
               return _root1;
            }
            private set 
            {
                _root1 = value;
            }
        }
        public double Root2 
        { 
            get
            {
               return _root2; 
            }
            private set 
            {
                _root2 = value; 
            }
        }
        public double D 
        { 
            get
            {
                return _d; 
            }
               
            private set 
            {
                _d = value; 
            }
        }

        /// <summary>
        /// получает дискриминант
        /// </summary>
        private void GetD()
        {
            D = _b * _b - 4 * _a * _c;
            if (D < 0)
            {
                throw new EquationSolverException(string.Format("Дискриминант отрицательный, корни не веществены - {0}", D));
            }
        }

        /// <summary>
        /// получает первый корень
        /// </summary>
        private void GetRoot1()
        {
            Root1 = (-_b + Math.Sqrt(D)) / 2 * _a;
        }

        /// <summary>
        /// получает второй корень
        /// </summary>
        private void GetRoot2()
        {
            Root2 = (-_b - Math.Sqrt(D)) / 2 * _a;
        }

        private double _a = 1;
        private double _b;
        private double _c;
        //private byte _rootCount;
        private double _root1;
        private double _root2;
        private double _d;
    }
}
