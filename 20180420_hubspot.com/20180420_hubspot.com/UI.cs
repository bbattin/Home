using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180420_hubspot.com
{
    class UI
    {
        /// <summary>
        /// запрашиваем API-ключ у пользователя
        /// </summary>
        /// <returns></returns>
        public static string GetHapikey()
        {
            Console.WriteLine("Enter your hapikey: ");
            string hapikey = Console.ReadLine();
            return hapikey;
        }

        /// <summary>
        /// запрашиваем количество контактов, которые нужно вывести
        /// </summary>
        /// <returns></returns>
        public static string GetCountContacts()
        {
            Console.WriteLine("Enter count contacts (max 100): ");
            string count = Console.ReadLine();
            return count;
        }
    }
}
