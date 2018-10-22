using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._02._28_Live
{
    class Ocean
    {
        private Cell[,] _cells;
        static private int _numRows = 25;
        static private int _numCols = 70;
        private int size = _numRows * _numCols;
        private int _numPrey = 150;
        private int _numPredators = 20;
        private int _numObstacles = 75;
        public Random random = new Random();

        // константы
        public const char DEFAULTIMAGE = '-';
        public const char PREYIMAGE = 'f';
        public const char PREDIMAGE = 'S';
        public const char OBSTACLEIMAGE = '#';

        public const int DEFAULTNUMITERATIONS = 1000;
        public const int TIMETOFEED = 6;
        public const int TIMETOREPRODUCE = 6;

        //public const int NUMOBSTACLES = 75;
        //public const int NUMPREDATORS = 20;
        //public const int NUMPREY = 150;


        public Ocean()
        {
            _cells = new Cell[_numRows, _numCols];
            Init();
        }

        public int NumRows
        {
            get
            {
                return _numRows;
            }
            
        }

        public int NumCols
        {
            get
            {
                return _numCols;
            }

        }

        public int NumPrey
        {
            get
            {
                return _numPrey;
            }
            set
            {
                // добавить валидацию
                _numPrey = value;
            }
        }

        public int NumPredators
        {
            get
            {
                return _numPredators;
            }
            set
            {
                // добавить валидацию
                _numPredators = value;
            }
        }

        /// <summary>
        /// индексатор для получения клетки по индексам
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public Cell this[int i, int j]
        {
            get
            {
                if (IsValidIndex(i, j))
                {
                    return _cells[i, j];
                }
                else
                {
                    return null;
                }

            }
            set
            {
                if (IsValidIndex(i, j))
                {
                    _cells[i, j] = value;
                }

            }
        }

        private bool IsValidIndex(int i, int j)
        {
            return i >= 0 && i < _numRows && j >= 0 && j < _numCols;
        }

        /// <summary>
        /// запрашивает количество преград, хищников, добычи и вставляет их в океан
        /// </summary>
        private void Init()
        {
            AddEmptyCells();
            AddObstacles();
            AddPredators();
            AddPrey();
            Cell.ocean1 = this;
        }

        /// <summary>
        /// добавление пустых клеток
        /// </summary>
        private void AddEmptyCells()
        {
            for (int i = 0; i < _numRows; i++)
            {
                for (int j = 0; j < _numCols; j++)
                {
                    _cells[i, j] = new Cell(new Coordinate(i, j));
                }
            }
        }

        /// <summary>
        /// устанавиливает преграды в океане
        /// </summary>
        private void AddObstacles()
        {
            Coordinate empty;
            for (int i = 0; i < _numObstacles; i++)
            {
                empty = GetEmptyCellCord();
                _cells[empty.Y, empty.X] = new Obstacle(empty);
            }
        }

        /// <summary>
        /// получаем рандомные координаты пустой ячейки
        /// </summary>
        /// <returns></returns>
        private Coordinate GetEmptyCellCord()
        {
            int x,
                y;
            Coordinate empty;
            do
            {
                x = random.Next(0, _numCols - 1);
                y = random.Next(0, _numRows - 1);

            } while (_cells[y, x].Image != DEFAULTIMAGE);

            empty = _cells[y, x].Offset;
            _cells[y, x] = null;
            return empty;
        }

        /// <summary>
        /// добавляем добычу в океан
        /// </summary>
        private void AddPrey()
        {
            Coordinate empty;
            for (int i = 0; i < _numPrey; i++)
            {
                empty = GetEmptyCellCord();
                _cells[empty.Y, empty.X] = new Prey(empty);
            }
        }

        /// <summary>
        /// добавляем хищников в океан
        /// </summary>
        private void AddPredators()
        {
            Coordinate empty;
            for (int i = 0; i < _numPredators; i++)
            {
                empty = GetEmptyCellCord();
                _cells[empty.Y, empty.X] = new Predator(empty);
            }
        }

        // методы отображения

        private void DisplayBorder()
        {
            Console.Write("\n");
            for (int i = 0; i < _numCols; i++)
            {
                Console.Write("*");
                
            }
            Console.Write("\n");
        }

        private void DisplayCells()
        {
            for (int i = 0; i < _numRows; i++)
            {
                for (int j = 0; j < _numCols; j++)
                {
                    _cells[i, j].Display();
                    
                }
                Console.Write("\n");
            }
        }

        private void DisplayStats(int iteration)
        {
            Console.WriteLine();
            Console.WriteLine("Iteration number: {0}, Obstacles: {1}, Predators: {2}, Prey: {3}", ++iteration, _numObstacles, _numPredators, _numPrey);
            Console.WriteLine();
        }

       /// <summary>
       /// метод запуска процесса моделирования
       /// </summary>
        public void Run()
        {
            
            for (int i = 0; i < DEFAULTNUMITERATIONS; i++)
            {
               
                if (_numPredators > 0 && _numPrey > 0)
                {

                    for (int j = 0; j < _numRows; j++)
                    {
                        for (int k = 0; k < _numCols; k++)
                        {
                            _cells[j, k].Process();
                        }
                    }
                    DisplayStats(i);
                    DisplayCells();
                    DisplayBorder();
                    //System.Threading.Thread.Sleep(1000);
                    Console.ReadKey();
                    Console.Clear();
                    
                }
                
            }
            Console.WriteLine("End of simulation");
            Console.ReadKey();
            
        }
        

        
    }
}
