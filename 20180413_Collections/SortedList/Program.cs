using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создадим коллекцию сортированного списка

            SortedList<string, string> UserInfo = new SortedList<string, string>();

            // Добавим несколько элементов в коллекию
            UserInfo.Add("Zack", "12345");
            UserInfo.Add("Den", "12345");
            UserInfo.Add("Alex", "12345");
            UserInfo.Add("John", "12345");
            UserInfo.Add("Elhm", "12345");
            UserInfo.Add("Lamar", "12345");

            // Коллекция ключей
            ICollection<string> keys = UserInfo.Keys;

            // Теперь используем ключи, для получения значений
            foreach (string s in keys)
            {
                Console.WriteLine("User: {0}, Password: {1}", s, UserInfo[s]);
            }

            Console.ReadLine();
        }
    }
}
