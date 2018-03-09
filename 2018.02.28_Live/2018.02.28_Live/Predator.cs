using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._02._28_Live
{
    class Predator : Prey
    {
        private int _timeToFeed = 6;

        public Predator(char image = 'S')
                    : base(image)
        {
        }

        public Predator(Coordinate z) : base(z)
        {
            _image = Ocean.PREDIMAGE;
        }

        public override void Process()
        {
            Coordinate toCoord;
            if (--_timeToFeed <= 0) // хищник умирает
            {
                AssignCellAt(Offset, new Cell(Offset));
                ocean1.NumPredators = ocean1.NumPredators - 1;
                //this = null; ?
            }
            else // съедает соседнюю добычу, если есть
            {
                toCoord = GetPreyNeighborCoord();
                if (toCoord != Offset)
                {
                    ocean1.NumPrey = ocean1.NumPrey - 1;
                    _timeToFeed = Ocean.TIMETOFEED;
                    MoveFrom(Offset, toCoord);
                }
                else
                {
                    base.Process(); // перемещается на пустую ячейку, если это возможно 
                }
            }
        }


        protected override Cell Reproduce(Coordinate anOffset)
        {
            Predator temp = new Predator(anOffset);
            ocean1.NumPredators = ocean1.NumPredators + 1;
            return temp;
        }

    }
}
