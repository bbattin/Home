using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._02._28_Live
{
    class Coordinate
    {
        private int _x;
        private int _y;


        public Coordinate(int y, int x)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get
            {
                return _x;      
            }
            set
            {
                if (value >= 0)
                {
                    _x = value;
                }
                
            }
        }

        public int Y
        {
            get
            {
                return _y;      
            }
            set
            {
                if (value >= 0)
                {
                    _y = value;
                }
            }
        }

    }
}
