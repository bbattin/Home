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
        delegate void CInfo(C info);

        static void Main(string[] args)
        {
            AFactory aDel;
            aDel = BuildC; // ковариантность
            A p = aDel("Tom");
            p.Display();

            CInfo cInfo = GetAInfo; // контравариантность
            C client = new C("Alice");
            cInfo(client);

            Console.ReadKey();
        }
        private static B BuildC(string name)
        {
            return new B(name);
        }

        private static void GetAInfo(A p)
        {
            p.Display();
        }
    }
}
