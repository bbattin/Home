using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class BubbleSort : Sorter
    {
        /// <summary>
        /// пузырьковая сортировка
        /// </summary>
        /// <param name="items"></param>
        public override void Sort(int[] items)
        {
            bool swapped;
            OnStarted();
            do
            {
                swapped = false;
                for (int i = 1; i<items.Length; i++)
                {
                    ToCompare(i - 1, i);
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        Swap(items, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);
            OnFinished();
        }
    }
}
