using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class InsertionSort : Sorter
    {
        /// <summary>
        /// сортировка вставками
        /// </summary>
        /// <param name="items"></param>
        public override void Sort(int[] items)
        {
            
            int sortedRangeEndIndex = 1;
            OnStarted();
            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex].CompareTo(items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }
            OnFinished();
        }

        private int FindInsertionIndex(int[] items, int valueToInsert)
        {
            for (int index = 0; index < items.Length; index++)
            {
                ToCompare(index - 1, index);
                if (items[index].CompareTo(valueToInsert) > 0)
                {
                    return index;
                }
            }

            throw new InvalidOperationException("The insertion index was not found");
        }

        private void Insert(int[] itemArray, int indexInsertingAt, int indexInsertingFrom)
        {
            // itemArray =       0 1 2 4 5 6 3 7
            // insertingAt =     3
            // insertingFrom =   6
            // 
            // Действия:
            //  1: Сохранить текущий индекс в temp
            //  2: Заменить indexInsertingAt на indexInsertingFrom
            //  3: Заменить indexInsertingAt на indexInsertingFrom в позиции +1
            //     Сдвинуть элементы влево на один.
            //  4: Записать temp на позицию в массиве + 1.

            ToMoved(indexInsertingAt, indexInsertingFrom);

            // Шаг 1.
            int temp = itemArray[indexInsertingAt];

            // Шаг 2.

            itemArray[indexInsertingAt] = itemArray[indexInsertingFrom];

            // Шаг 3.
            for (int current = indexInsertingFrom; current > indexInsertingAt; current--)
            {
                itemArray[current] = itemArray[current - 1];
            }

            // Шаг 4.
            itemArray[indexInsertingAt + 1] = temp;
        }
    }
}
