﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class MergeSort : Sorter
    // сортировка слиянием
    {
        public override void Sort(int[] items)
        {
            OnStarted();
            RecurseSort(items);
            
            OnFinished();
        }

        public void RecurseSort(int[] items)
        {
            
            if (items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];
            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);
            RecurseSort(left);
            RecurseSort(right);
            Merge(items, left, right);
           
        }

        private void Merge(int[] items, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length;
            while (remaining > 0)
            {
                ToCompare(leftIndex, rightIndex);
                if (leftIndex >= left.Length)
                {
                    ToMoved(targetIndex, rightIndex + 1);
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    ToMoved(targetIndex, leftIndex + 1);
                    items[targetIndex] = left[leftIndex++];
                }
                
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    ToMoved(targetIndex, leftIndex + 1);
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    ToMoved(targetIndex, rightIndex + 1);
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }
    }
}
