using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180402_iterators
{
    class Container : IEnumerable, IEnumerator
    {

        public Container(int size)
        {
            _items = new object[size];
        }

        public object this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                if (_items[index] != null)
                {
                    _items[index] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(object item)
        {
            _items[_count++] = item;
        }

        // возвращаем перечислитель
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        // реализуем интерфейс IEnumerator

        public bool MoveNext()
        {
            if (_count == _items.Length - 1)
            {
                Reset();
                return false;
            }

            _count++;
            return true;
        }

        public void Reset()
        {
            _count = 0;
        }

        public object Current
        {
            get
            {
                return _items[_count];
            }
        }

        private int _count = 0;
        private object[] _items;    // элементы контейнера
    }
}
