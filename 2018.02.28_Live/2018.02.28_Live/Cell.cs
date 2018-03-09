using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._02._28_Live
{
    class Cell
    {
        public static Ocean ocean1;
        private Coordinate _offset;
        protected char _image = '-';

        public Cell(Coordinate z)
        {
            _offset = z;
            
        }

        public Cell(char image)

        {
            _image = image;

        }

        public Coordinate Offset
        {
            // возвращает смещение
            get
            {
                return _offset;      
            }
            // устанавливает смещение
            set
            {
               _offset = value;
            }
        }

        public char Image
        {
            get
            {
                return _image;      
            }
            
        }

        
        /// <summary>
        /// возвращает ячейку по координатам
        /// </summary>
        /// <param name="aCoord"></param>
        /// <returns></returns>
        protected Cell GetCellAt(Coordinate aCoord)
        {
            return ocean1[aCoord.Y, aCoord.X];
        }

        /// <summary>
        /// помещает ячейку по координатам в океан1
        /// </summary>
        /// <param name="aCoord"></param>
        /// <param name="aCell"></param>
        protected void AssignCellAt(Coordinate aCoord, Cell aCell)
        {
            ocean1[aCoord.Y, aCoord.X] = aCell;
        }

        /// <summary>
        /// получение изображения соседней ячейки
        /// </summary>
        /// <param name="animage"></param>
        /// <returns></returns>
        private Cell GetNeighborWithImage(char animage)
        {
            Cell[]neighbors = new Cell[4];
            int count = 0;
            if (North().Image == animage)
            {
                neighbors[count++] = North();
            }
            if (South().Image == animage)
            {
                neighbors[count++] = South();
            }
            if (East().Image == animage)
            {
                neighbors[count++] = East();
            }
            if (West().Image == animage)
            {
                neighbors[count++] = West();
            }
            if (count == 0)
            {
                return this;
            }
            else
            {
                return neighbors[ocean1.random.Next(0, count - 1)];
            }
        }

        /// <summary>
        /// ищет соседнюю пустую ячейку
        /// </summary>
        /// <returns></returns>
        protected Coordinate GetEmptyNeighborCoord()
        {
            return GetNeighborWithImage(Ocean.DEFAULTIMAGE).Offset;
        }

        /// <summary>
        /// ищет соседнюю ячейку с добычей
        /// </summary>
        /// <returns></returns>
        protected Coordinate GetPreyNeighborCoord()
        {
            return GetNeighborWithImage(Ocean.PREYIMAGE).Offset;
        }

        private Cell North()
        {
            int yvalue;
            yvalue = (_offset.Y > 0) ? (_offset.Y - 1) : (ocean1.NumRows - 1);
            return ocean1[yvalue, _offset.X];
        }

        private Cell South()
        {
            int yvalue;
            yvalue = (_offset.Y + 1) % ocean1.NumRows;
            return ocean1[yvalue, _offset.X];
        }

        private Cell East()
        {
            int xvalue;
            xvalue = (_offset.X + 1) % ocean1.NumCols;
            return ocean1[Offset.Y, xvalue];
        }

        private Cell West()
        {
            int xvalue;
            xvalue = (_offset.X > 0) ? (_offset.X - 1) : (ocean1.NumCols - 1);
            return ocean1[_offset.Y, xvalue];
        }

        /// <summary>
        /// выводит изображение по соответствующему смещению
        /// </summary>
        protected virtual Cell Reproduce(Coordinate anOffset)
        {
            Cell temp = new Cell(anOffset);
            return temp;
        }

        /// <summary>
        /// выводит изображение по соответствующему смещению
        /// </summary>
        internal void Display()
        {
            Console.Write(_image);
        }

        /// <summary>
        /// перемещает в соседнюю ячейку, учитывая правила
        /// </summary>
        public virtual void Process()
        {
            
        }
    }
}
