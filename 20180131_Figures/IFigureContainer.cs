using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    interface IFigureContainer
    {
        Figure2D this[int index] { get; }
        int Count { get; }

        bool Add(Figure2D obj);
    }
}
