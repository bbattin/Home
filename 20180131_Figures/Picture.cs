using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Picture : IFigureContainer, IResizable
    {
        private Figure2D[] _items;
        
        private int _countFiguresReal = 0;   // счетчик подсчета количества добавленных фигур

        /// <summary>
        /// конструктор для создания массива фиксированного размера
        /// </summary>
        /// <param name="size"></param>
        public Picture(int size)
        {
            _items = new Figure2D[size];
        }

        public int CountFiguresReal
        {
            get
            {
                return _countFiguresReal;
            }
        }

        public int Count => CountFiguresReal;

        Figure2D IFigureContainer.this[int index]
        {
            get
            {
                Figure2D a = null;
                if (index >= 0)
                {
                    //a = new Figure2D(_items[index]); // доработать возврат копии
                    a = _items[index]/*.Clone()*/;
                }
                return a;
            }
        }
        

        /// <summary>
        /// индексатор для доступа к методам отдельной фигуры
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Figure2D this[int index]
        {
            get
            {
                Figure2D a = null;
                if (index >= 0)
                {
                    a = _items[index]; // доработать возврат копии
                }
                return a;
            }
            
        }

        /// <summary>
        /// добавление фигуры в массив
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(Figure2D obj)
        {
            bool rezult = false;
            if (_countFiguresReal < _items.Length)
            {
                _items[_countFiguresReal] = obj;
                _countFiguresReal++;
                rezult = true;
            }
            return rezult;
        }

        /// <summary>
        /// отобразить все фигуры в массиве
        /// </summary>
        /// <param name="clear"></param>
        public void ShowAll(bool clear = false)
        {
           
            int oldX = Console.CursorLeft;
            int oldY = Console.CursorTop;

            for (int i = 0; i < _countFiguresReal; i++)
            {
                if (clear)
                {
                    Console.ForegroundColor = Console.BackgroundColor;
                }
                else
                {
                    Console.ForegroundColor = _items[i].Color;
                }

                _items[i].Show();
                
            }

        }

        /// <summary>
        /// скрыть все фигуры в массиве
        /// </summary>
        public void HideAll()
        {
            ShowAll(true);
        }

        ///// <summary>
        ///// масштабирование всех фигур в массиве
        ///// </summary>
        ///// <param name="procent"></param>
        //public void ScaleAll(int procent)
        //{
        //    for (int i = 0; i < _countFiguresReal; i++)
        //    {
        //        _items[i].Scale(procent);
        //    }
        //}

        public void Scale(int procent)
        {
            Circle a;
            Rectangle b;
            Triangle c;

            for (int i = 0; i < _countFiguresReal; i++)
            {
                if (_items[i] is Circle)
                {
                    a = (Circle)_items[i];
                    a.Scale(procent);
                }
                if (_items[i] is Rectangle)
                {
                    b = (Rectangle)_items[i];
                    b.Scale(procent);
                }
                if (_items[i] is Triangle)
                {
                    c = (Triangle)_items[i];
                    c.Scale(procent);
                }
            }
        }

        /// <summary>
        /// движение всех фигур поочередно по x
        /// </summary>
        /// <param name="longMove"></param>
        public void MoveFigures(int longMove)
        {
           
            for (int i = 0; i < _countFiguresReal; i++)
            {
                _items[i].Show();
                
                for (int j = 0; j < longMove; j++)
                {
                    System.Threading.Thread.Sleep(800);
                    _items[i].Hide();
                    _items[i].MovePoint(1, 0);
                    _items[i].Show();
                }
            }
            
            
        }

        /// <summary>
        /// движение всех фигур одновременно по x
        /// </summary>
        /// <param name="longMove"></param>
        public void MoveAllFigures(int longMove)
        {
            ShowAll();
            
            for (int j = 0; j < longMove; j++)
            {
                System.Threading.Thread.Sleep(800);
                for (int i = 0; i < _countFiguresReal; i++)
                {
                    _items[i].Hide();
                    _items[i].MovePoint(1, 0);
                    _items[i].Show();

                }
            }


        }

        /// <summary>
        /// перемещение всех фигур по отношению к координатам
        /// </summary>
        public void MoveAllTo(int x, int y)
        {
            for (int i = 0; i < _countFiguresReal; i++)
            {

                _items[i].X = x;
                _items[i].Y = y;
                _items[i].Show();

            }

        }

        
    }

    
}
