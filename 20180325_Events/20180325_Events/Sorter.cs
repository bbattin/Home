using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{

    class StartedEventArgs : EventArgs
    {
        public StartedEventArgs()
        {

        }

    }

    class FinishedEventArgs : EventArgs
    {
        public FinishedEventArgs()
        {

        }

    }

    delegate void CompareItems(object sender, CompareAndMovedEventArgs args);
    delegate void MovedItems(object sender, MovedAndCompareEventArgs args);

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
            OnStarted();
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
            OnFinished();
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
                ToMoved(left, right);
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
                _element(this, new CompareAndMovedEventArgs(a, b));
            }
        }

        protected void ToMoved(int i, int j)
        {
            if (_item != null)
            {
                _item(this, new MovedAndCompareEventArgs(i, j));
            }
        }

        protected void OnStarted()
        {
            if (Started != null)
            {
                Started(this, new EventArgs());
            }
        }

        protected void OnFinished()
        {
            if (Started != null)
            {
                Finished(this, new EventArgs());
            }
        }

        CompareItems _element;
        MovedItems _item;
        //StartedEventArgs _start;
        //FinishedEventArgs _finish;


    }
}
