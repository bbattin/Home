using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180402_CoveartDelegate
{
    class A
    {
        public string Name { get; set; }

        public A(string name)
        {
            Name = name;
        }
        public void Display()
        {
            Console.WriteLine(Name);
        }
    }
}
