using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180315_Exceptions
{
    class SquareEquationSolver
    {
        public SquareEquationSolver(int a, int b, int c)
        {
            GetD(a, b, c);
            GetRoot1(a, b, c);
            GetRoot2(a, b, c);
        }

        public int RootCount { get => _rootCount; set => _rootCount = value; }

        public void GetD(int a, int b, int c)
        {
            _d = b * b - 4 * a * c;
        }

        public void GetRoot1(int a, int b, int c)
        {
            _root1 = -b + _d / 2 * a;
        }

        public void GetRoot2(int a, int b, int c)
        {
            _root2 = -b - _d / 2 * a;
        }

        private int _rootCount;
        private double _root1;
        private double _root2;
        private double _d;
    }
}
