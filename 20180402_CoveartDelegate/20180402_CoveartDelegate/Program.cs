using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180402_CoveartDelegate
{
    class Program
    {
        delegate A AFactory(string name);
        delegate B BFactory(string name);
        delegate void CInfo(C info);

        static void Main(string[] args)
        {
            AFactory a1;
            a1 = BuildB; // ковариантность
            A p = a1("class A use method of class B (delegate of class A, B : A)");
            p.Display();

            AFactory a2;
            a2 = BuildC; // ковариантность
            p = a2("class A use method of class C (delegate of class A, C : B, B : A)");
            p.Display();

            BFactory b;
            b = BuildC; // ковариантность
            p = b("class B use method of class C (delegate of class B, C : B)");
            p.Display();

            CInfo cInfo = GetAInfo; // контравариантность
            C c1 = new C("class C use method of class A (delegate of class C, C : B, B : A)");
            cInfo(c1);

            cInfo = GetBInfo; // контравариантность
            C c2 = new C("class C use method of class B (delegate of class C, C : B)");
            cInfo(c2);

            Console.ReadKey();
        }

        private static B BuildB(string name)
        {
            return new B(name);
        }

        private static C BuildC(string name)
        {
            return new C(name);
        }

        private static void GetAInfo(A p)
        {
            p.Display();
        }

        private static void GetBInfo(B p)
        {
            p.Display();
        }
    }
}
