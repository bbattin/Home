using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180119_Classes
{
    class Program
    {
        static void Main(string[] args)
        {

            Group GroupM3 = Group.CreateGroup();
            
            UI.PrintGroup(GroupM3);

            string name = UI.EnterNameForSearch();
            UI.RezultSearchByName(GroupM3[name]);

            Student stud;
            stud = GroupM3.SearchByNumberBookStudent();
            UI.PrintStudent(stud);

            UI.EditByNumberBookStudent(GroupM3);

            // копирование через конструктор
            Group GroupM4 = new Group(GroupM3);
            GroupM4.Name = "Copy group";

            UI.DelStudent(GroupM4);

            Console.ReadKey();
            Console.Clear();

            UI.PrintGroup(GroupM4);

            Console.ReadKey();
        }
    }
}