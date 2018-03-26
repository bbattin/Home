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

    delegate bool CompareItems(object sender, CompareEventArgs args);
    delegate void MovedItems(object sender, MovedEventArgs args);

    //delegate void Started(object sender, CompareEventArgs args);
    //delegate void Finished(object sender, MovedEventArgs args);

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
                    ToCompare(items[i - 1], items[i]);
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
            ToMoved(left, right);
            if (left != right)
            {
                int temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        
        public event CompareItems Compare
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

        public event MovedItems Moved
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

        public event EventHandler Started;
        public event EventHandler Finished;


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

        CompareItems _element;
        MovedItems _item;
            


    }
}
