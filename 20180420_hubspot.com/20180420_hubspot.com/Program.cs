using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace _20180420_hubspot.com
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeOffset = "1524480259611";
            string result = GetJsonWithContacts(timeOffset);
            Console.Write(result);

            ResponseJson responseJson = JsonConvert.DeserializeObject<ResponseJson>(result);
            Console.WriteLine();

            Console.WriteLine(responseJson.Responses.Count);

            List<Contact> contacts = CreateListContacts(responseJson);

            CreateCSVFile(contacts);

            Console.ReadKey();
        }

        /// <summary>
        /// создание списка контактов
        /// </summary>
        /// <param name="responseJson"></param>
        /// <returns></returns>
        private static List<Contact> CreateListContacts(ResponseJson responseJson)
        {
            List<Contact> contacts = new List<Contact>();
            Contact a = new Contact();
            foreach (Response p in responseJson.Responses)
            {
                a.Firstname = p.Properties.Firstname.Value;
                a.Lastname = p.Properties.Lastname.Value;
                a.Lifecyclestage = p.Properties.Lastmodifieddate.Value;
                a.Company = p.Properties.Company.Value;
                a.Vid = p.Vid;
                a.PortalId = p.PortalId;
                contacts.Add(a);
            }
            return contacts;
        }

        /// <summary>
        /// создание CSV файла со списком контактов
        /// </summary>
        /// <param name="contacts"></param>
        private static void CreateCSVFile(List<Contact> contacts)
        {
            StreamWriter csv = new StreamWriter("contacts.csv", true, Encoding.GetEncoding(1251));   // Win-кодировка
            csv.WriteLine("Vid; Firstname; Lastname; Lastmodifieddate; Company; PortalId");      // заголовок


            foreach (Contact p in contacts)
            {
                csv.WriteLine("{0};{1};{2};{3};{4};{5}", p.Vid, p.Firstname, p.Lastname, p.Lifecyclestage, p.Company, p.PortalId);   
            }

            csv.Close();
        }

        /// <summary>
        /// отправка GET запроса и получение джейсона со списком контактов
        /// </summary>
        /// <param name="timeOffset"></param>
        /// <returns></returns>
        private static string GetJsonWithContacts(string timeOffset)
        {
            string hapikey = "demo";
            string countContacts = "10";
            string vidOffset = "5875024";
            string url = "https://api.hubapi.com/contacts/v1/lists/recently_updated/contacts/recent?hapikey=" + hapikey + "&count=" + countContacts + "&timeOffset=" + timeOffset + "&vidOffset=" + vidOffset;
            WebClient client = new WebClient();
            string result = client.DownloadString(url);
            return result;
        }

       
    }
}
