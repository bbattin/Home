using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180119_Classes
{
    class UI
    {

        /// <summary>
        /// узнаем максимальное количество студентов у пользователя
        /// </summary>
        /// <returns></returns>
        public static int GetCountStudents()
        {
            int countStudents;
            string countSt;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter maximum count of students: ");
                countSt = Console.ReadLine();
            } while (int.TryParse(countSt, out countStudents) == false);
            return countStudents;
        }

        /// <summary>
        /// узнаем максимальное количество оценок для одного студента у пользователя
        /// </summary>
        /// <returns></returns>
        public static int GetCountMarks()
        {
            int countMarks;
            string countMar;
            do
            {
                Console.WriteLine("Enter maximum marks for one student: ");
                countMar = Console.ReadLine();
            } while (int.TryParse(countMar, out countMarks) == false);
            return countMarks;
        }

        public static void GetNameGroup(Group grp)
        {
            Console.WriteLine(Environment.NewLine + "[Group create]" + Environment.NewLine);

            Console.Write("Name: ");
            grp.Name = Console.ReadLine();

            Console.Write("Spec: ");
            grp.Spec = Console.ReadLine();
        }

        

        /// <summary>
        /// добавление оценок студентам групы
        /// </summary>
        /// <param name="grp"></param>
        public static void EnterMarksForStudents(Group grp)
        {
            ConsoleKey use;
            byte mark = 0;

            Console.WriteLine(Environment.NewLine + "[Enter Students Assess]" + Environment.NewLine);
            

            for (int i = 0; i < grp.CountStudentsReal; i++)
            {
                Console.Write("Assess for student {0} with book number {1} : ", grp[i].Name, grp[i].NumberBook);

                do
                {
                    use = Console.ReadKey().Key;

                    mark = Key2Number(use);

                    // проверяем что это число входит в диапазон от одного до пяти 
                    if (mark > 0 && mark <= 5)
                    {
                        grp[i].AddMark(mark);
                        Console.Write(" ");
                    }
                    else
                    {
                        break;
                    }

                } while (mark != 0 && grp[i].CountMarksReal < grp[i].CountMarks);


                Console.WriteLine();
            }


        }

        /// <summary>
        /// по номеру клавиши получаем число
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte Key2Number(ConsoleKey key)
        {
            byte num = 0;
            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    num = 1;
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    num = 2;
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    num = 3;
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    num = 4;
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    num = 5;
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    num = 6;
                    break;
                case ConsoleKey.NumPad7:
                case ConsoleKey.D7:
                    num = 7;
                    break;
                case ConsoleKey.NumPad8:
                case ConsoleKey.D8:
                    num = 8;
                    break;
                case ConsoleKey.NumPad9:
                case ConsoleKey.D9:
                    num = 9;
                    break;
                default:
                    break;
            }

            return num;
        }

        /// <summary>
        /// печать данных о студенте
        /// </summary>
        /// <param name="s"></param>
        public static void PrintStudent(Student s)
        {

            if (s != null)
            {
                Console.Write(Environment.NewLine + "Name: {0,25}, number: {1,10}, average score: {2}, assessments: ", s.Name, s.NumberBook, (float)s.AverageMark);

                if (s.CountMarksReal == 0)
                {
                    Console.Write("  no assessments!");
                    return;
                }

                for (int i = 0; i < s.CountMarksReal; i++)
                {
                    Console.Write("{0,3} ", s[i]);
                }

            }
            else
            {
                Console.WriteLine("No students");
            }
            
            
        }

        /// <summary>
        /// печать группы со студентами 
        /// </summary>
        /// <param name="p"></param>
        public static void PrintGroup(Group p)
        {
            Console.WriteLine(Environment.NewLine + "Group name: {0,10}, specialty: {1,15}, students: ", p.Name, p.Spec);
            for (int i = 0; i < p.CountStudentsReal; i++)
            {
                PrintStudent(p[i]);
            }

            PrintAverGr(p);
        }

        public static void PrintAverGr(Group g)
        {
            Console.WriteLine();
            Console.Write(Environment.NewLine + "Average score for the group: {0} - {1}", g.Name, (float)g.AverageMark());
        }

        /// <summary>
        /// спрашиваем у пользователя по какому имени искать
        /// </summary>
        /// <returns></returns>
        public static string EnterNameForSearch()
        {
            string name;
            Console.WriteLine();
            Console.Write(Environment.NewLine + "Is there a student with that name?  ");
            name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// результат поиска по имени
        /// </summary>
        /// <param name="nameSt"></param>
        public static void RezultSearchByName(bool nameSt)
        {
            if (nameSt)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }

        public static string EnterNumberBookForSearch()
        {
            string number;
            Console.WriteLine();
            Console.Write(Environment.NewLine + "Search by number book of student  ");
            number = Console.ReadLine();
            return number;
        }

        /// <summary>
        /// редактирование студента по номеру зачетки
        /// </summary>
        /// <param name="g"></param>
        public static void EditByNumberBookStudent(Group g)
        {
            Console.WriteLine();
            Console.WriteLine(Environment.NewLine + "[Edit student]");
            Student st = g.SearchByNumberBookStudent();
            if (st == null)
            {
                Console.WriteLine("No students");
                return;
            }
            
            string answer;
            byte mark;
            ConsoleKey use;


            Console.WriteLine();
            Console.Write(Environment.NewLine + "What needs to be edited?  ");
            
            answer = Console.ReadLine().ToLower();

            if (answer == "name")
            {
                Console.WriteLine();
                Console.Write(Environment.NewLine + "Enter name:  ");
                st.Name = Console.ReadLine();
                
            }
            else
            {
                Console.WriteLine();
                Console.Write(Environment.NewLine + "Enter marks for adding:  ");
                do
                {
                    use = Console.ReadKey().Key;

                    mark = Key2Number(use);

                    if (mark > 0 && mark <= 5)
                    {
                        st.AddMark(mark);
                        Console.Write(" ");
                    }
                    else
                    {
                        break;
                    }

                } while (mark != 0 && st.CountMarksReal < st.CountMarks);
            }

            PrintStudent(st);

        }

        public static void DelStudent(Group g)
        {
            Console.WriteLine();
            Console.WriteLine(Environment.NewLine + "[Delete student]");
            if (g.DeleteStudentByNumberBook())
            {
                Console.WriteLine(Environment.NewLine + "Done delete");
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "No students");
            }
           
            
        }

    }
}
