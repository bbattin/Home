using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180402_iterators
{
    class Container
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

        private int _count = 0;
        private object[] _items;    // элементы контейнера
    }
}
