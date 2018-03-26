using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class CompareEventArgs : EventArgs
    {
        public CompareEventArgs(int a, int b)
        {
            FirstNumber = a;
            SecondNumber = b;
        }

        // данные, описывающие событие
        public int FirstNumber { get; private set; }   // значение первого элемента, который сравниваем
        public int SecondNumber { get; private set; }  // значение второго элемента, который сравниваем
    }

    class MovedEventArgs : EventArgs
    {
        public MovedEventArgs(int i, int j)
        {
            IndexFrom = i;
            IndexTo = j;
        }

        // данные, описывающие событие
        public int IndexFrom { get; private set; } // индекс изначального положения элемента
        public int IndexTo { get; private set; }   // индекс нового положения элемента
    }

    delegate bool Compare(object sender, CompareEventArgs args);
    delegate void Moved(object sender, MovedEventArgs args);

    delegate void Started(object sender, CompareEventArgs args);
    delegate void Finished(object sender, MovedEventArgs args);

    class Sorter
    {

        /// <summary>
        /// пузырьковая сортировка
        /// </summary>
        /// <param name="items"></param>
        public void BubbleSort(int[] items)
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

        /// <summary>
        /// сортировка вставками
        /// </summary>
        /// <param name="items"></param>
        public void InsertionSort(int[] items)
        {
            int sortedRangeEndIndex = 1;

            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex].CompareTo(items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }
        }

        private int FindInsertionIndex(int[] items, int valueToInsert)
        {
            for (int index = 0; index < items.Length; index++)
            {
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

        public event Compare Compare
        {
            add
            {
                _element += value;
            }
            remove
            {
                _element -= value;
            }
        }

        public event Moved Moved
        {
            add
            {
                _item += value;
            }
            remove
            {
                _item -= value;
            }
        }


        protected void ToCompare(int a, int b)
        {
            if (_element != null)
            {
                _element(this, new CompareEventArgs(a, b));
            }
        }

        

        protected void ToMoved(int i, int j)
        {
            if (_item != null)
            {
                _item(this, new MovedEventArgs(i, j));
            }
        }

        Compare _element;
        Moved _item;
            


    }
}
