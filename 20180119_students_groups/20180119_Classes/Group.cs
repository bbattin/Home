using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180119_Classes
{
    class Group
    {
        private string _name;
        private string _spec;
        private Student[] _students = null;
        private int _countStudents;                    // кол-во студентов, заданных пользователем
        private int _countStudentsReal = 0;            // счетчик для добавления студентов

        // номера зачеток
        private ushort _startBookNum;
        private ushort _nextBookNum;

        
        static Random rand = new Random();
        
        public Group()
        {
            _startBookNum = (ushort)rand.Next(100000, 999999);
            _nextBookNum = _startBookNum;
        }

        
        public Group(string name, string spec, Student[] students) : this()
        {
            _name = name;
            _spec = spec;
            _students = students;
        }

       

        // конструктор копирования
        public Group(Group source)
        {
            _name = source.Name;
            _spec = source.Spec;
            _countStudents = source.CountStudents;
            _countStudentsReal = source.CountStudentsReal;

            if (source._students != null)
            {
                _students = new Student[_countStudents];

                for (int i = 0; i < _countStudentsReal; i++)
                {
                    // создаем студента при помощи конструктора копирования
                    _students[i] = new Student(source._students[i]);
                }
            }
        }


        #region PROPERTIES

        public int CountStudents
        {
            get
            {
                return _countStudents;
            }
            private set
            {
                _countStudents = value;
            }

        }

        public int CountStudentsReal
        {
            get
            {
                return _countStudentsReal;
            }
            

        }

        public ushort NextBookNum
        {
            get
            {
                return _nextBookNum;
            }
           

        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    _name = value;
                }
                
            }
        }

        public string Spec
        {
            get
            {
                return _spec;
            }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    _spec = value;
                }
                 
            }
        }



        #endregion

        #region INDEXATORS

        public Student this[int index]
        {
            get
            {
                if (IsValidIndex(index))
                {
                    return _students[index];
                }
                else
                {
                    return null;
                }
                
            }
            set
            {
                if (IsValidIndex(index))
                {
                    _students[index] = value;
                }
                   
            }
        }

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < _countStudentsReal;
        }

        public Student this[ushort numberBook]
        {
            get
            {
                Student retStud = null;

                for (int i = 0; i < _countStudentsReal; i++)
                {
                    if ((_students[i].NumberBook == numberBook))
                    {
                        retStud = new Student(_students[i]);    // возврат ссылки (!!! нарушение инкапсуляции) - исправлено
                        break;
                    }                    
                }

                return retStud; 
            }
            set
            {
                for (int i = 0; i < _countStudentsReal; i++)
                {
                    if ((_students[i].NumberBook == numberBook))
                    {
                        _students[i] = new Student(value);    // присваивание внешней ссылки (!!! нарушение инкапсуляции) - исправлено
                        break;
                    }

                }
                
            }
        }
        
        public bool this[string name]
        {
            get
            {
                name = name.ToLower();
                bool found = false;

                for (int i = 0; i < _countStudentsReal; i++)
                {
                    if ((_students[i].Name.ToLower() == name))
                    {
                        found = true;
                    }
                }

                return found;
            }
            
        }

        #endregion

        /// <summary>
        /// создаем группу по введенным данным
        /// </summary>
        /// <returns></returns>
        public static Group CreateGroup()
        {
            Group grp = new Group();
            UI.GetNameGroup(grp);

            grp.CountStudents = UI.GetCountStudents();

            EnterStudents(grp);
            UI.EnterMarksForStudents(grp);

            return grp;
        }

        /// <summary>
        /// ввод студентов в группу
        /// </summary>
        /// <param name="grp"></param>
        public static void EnterStudents(Group grp)
        {
            string name;
            ConsoleKey use;

            Console.WriteLine(Environment.NewLine + "[Add Students]" + Environment.NewLine);
            int countMarks = UI.GetCountMarks();
            do
            {
                Console.WriteLine("Student with book number {0}", grp.NextBookNum);

                Console.Write("Name: ");
                name = Console.ReadLine();

                Student stud = new Student(name, grp.NextBookNum);
                stud.CountMarks = countMarks;
                grp.AddStudent(stud);
                grp._nextBookNum++;

                Console.WriteLine(Environment.NewLine + "Anykey - next student. Esc - stop." + Environment.NewLine);
                use = Console.ReadKey(true).Key;


            } while (use != ConsoleKey.Escape && grp.CountStudentsReal < grp.CountStudents);
        }

        /// <summary>
        /// добавление студента
        /// </summary>
        /// <param name="newStudent"></param>
        public void AddStudent(Student newStudent)
        {
            
            // если еще нет массива студентов то создаем
            if (_students == null)
            {
                _students = new Student[_countStudents];
                _students[_countStudentsReal] = newStudent;
                _countStudentsReal++;
                

            }
            else
            {
                if (_countStudentsReal < _students.Length)
                {
                    _students[_countStudentsReal] = newStudent;
                    _countStudentsReal++;
                    

                }
                
            }
           
        }

        /// <summary>
        /// поиск средней оценки по группе
        /// </summary>
        /// <returns></returns>
        public double AverageMark()
        {
            double x = 0;
            double sum = 0;
            double rezult = 0;
           

            for (int i = 0; i < _countStudentsReal; i++)
            {
                x = _students[i].AverageMark;
                sum += x;
            }
            rezult = sum / _countStudentsReal;
            
            return rezult;
        }

        /// <summary>
        /// проверка есть ли студенты с указанным именем
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public bool SearchByNameStudent(string name)
        {
            //string name;
            //bool nameSt = false;
            //name = UI.EnterNameForSearch();

            bool nameSt = this[name];

            return nameSt;
            
            
        }

        /// <summary>
        /// поиск студента по номеру зачетки
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Student SearchByNumberBookStudent()
        {
            
            string number;
            ushort numberBook = 0;
            Student st;

            number = UI.EnterNumberBookForSearch();
            ushort.TryParse(number, out numberBook);
            st = this[numberBook];
            
            return st;

        }


        
        /// удаление студента по номеру зачетки
        /// </summary>
        /// <param></param>
        // public bool DeleteStudentByNumberBook(int numberBook) - частично исправлено
        public bool DeleteStudentByNumberBook()
        {
            Student st = SearchByNumberBookStudent();
            bool delete = false;
            Student[] students = new Student[CountStudents];

            if (st != null)
            {
                int j = 0;
                for (int i = 0; i < CountStudentsReal; i++)
                {

                    if (_students[i].NumberBook != st.NumberBook)
                    {
                        students[j] = new Student(_students[i]);
                        j++;
                    }

                }
                _students = students;
                _countStudentsReal--;
                delete = true;
            }
            
            return delete;                            
           
        }


    }
}
