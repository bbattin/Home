using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class QuickSort : Sorter
        // быстрая сортировка
    {
        Random _pivotRng = new Random();

        public override void Sort(int[] items)
        {
            OnStarted();
            Quicksort(items, 0, items.Length - 1);
            OnFinished();
        }

        private void Quicksort(int[] items, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = _pivotRng.Next(left, right);
                int newPivot = Partition(items, left, right, pivotIndex);

                Quicksort(items, left, newPivot - 1);
                Quicksort(items, newPivot + 1, right);
            }
        }

        private int Partition(int[] items, int left, int right, int pivotIndex)
        {
            int pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                ToCompare(i, pivotValue);
                if (items[i].CompareTo(pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }
    }
}
