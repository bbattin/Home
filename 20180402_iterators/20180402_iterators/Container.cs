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

        /// <summary>
        /// перемещение на одну позицию вперед в контейнере элементов
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (_index == _items.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        /// <summary>
        /// перемещение в начало контейнера
        /// </summary>
        public void Reset()
        {
            _index = -1;
        }

        /// <summary>
        /// текущий элемент в контейнере
        /// </summary>
        public object Current
        {
            get
            {
                return _items[_index];
            }
        }

        private int _index = -1;    // индекс для перечисления
        private int _count = 0;     // количество элементов
        private object[] _items;    // элементы контейнера
    }
}
