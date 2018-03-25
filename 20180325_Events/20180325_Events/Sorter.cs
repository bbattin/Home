using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    
    class Sorter
    {

        /// <summary>
        /// пузырьковая сортировка
        /// </summary>
        /// <param name="items"></param>
        public void Sort(int[] items)
        {
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        Swap(items, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);
        }

        /// <summary>
        /// меняет значение в массиве по индексу
        /// </summary>
        /// <param name="items"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        void Swap(int[] items, int left, int right)
        {
            if (left != right)
            {
                int temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

    }
}
