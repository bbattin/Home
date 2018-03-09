using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._02._28_Live
{
    class Prey : Cell
    {
        private int _timeToReproduce = 6;

        public Prey(char image = 'f')
            :base (image)
        {
        }

        public Prey(Coordinate z) : base(z)
        {
            _image = Ocean.PREYIMAGE;
        }

        /// <summary>
        /// перемещает из координаты фром в ту, в массивк целлс
        /// </summary>
        /// <param name="aCoord"></param>
        /// <returns></returns>
        protected void MoveFrom(Coordinate from, Coordinate to)
        {
            Cell toCell;
            --_timeToReproduce;
            if (to != from)
            {
                toCell = GetCellAt(to);
                toCell = null;
                Offset = to;
                AssignCellAt(to, this);
                if (_timeToReproduce <= 0)
                {
                    _timeToReproduce = Ocean.TIMETOREPRODUCE;
                    AssignCellAt(from, Reproduce(from));
                }
                else
                {
                    AssignCellAt(from, new Cell(from));
                }
            }
        }

        protected override Cell Reproduce(Coordinate anOffset)
        {
            Prey temp = new Prey(anOffset);
            ocean1.NumPrey = ocean1.NumPrey + 1;
            return temp;
        }

        public override void Process()
        {
            Coordinate toCoord;
            toCoord = GetEmptyNeighborCoord();
            MoveFrom(Offset, toCoord);
        }
    }
}
