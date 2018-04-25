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
            string result = GetContactList(timeOffset);
            Console.Write(result);

            ResponseJson responseJson = JsonConvert.DeserializeObject<ResponseJson>(result);
            Console.WriteLine();

            Console.WriteLine(responseJson.Responses.Count);

            CreateCSVFile(responseJson);

            Console.ReadKey();
        }

        private static void CreateCSVFile(ResponseJson responseJson)
        {
            StreamWriter csv = new StreamWriter("test.csv", true, Encoding.GetEncoding(1251));   // Win-кодировка
            csv.WriteLine("Vid; Firstname; Lastname; Lastmodifieddate; Company; PortalId");      // заголовок


            foreach (Response p in responseJson.Responses)
            {
                csv.WriteLine(ChekAndGetParametr(p.Vid) + ";" + ChekAndGetParametr(p.Properties.Firstname) + ";" 
                    + ChekAndGetParametr(p.Properties.Lastname) + ";" + ChekAndGetParametr(p.Properties.Lastmodifieddate) 
                    + ";" + ChekAndGetParametr(p.Properties.Company) + ";" + ChekAndGetParametr(p.PortalId));   
            }

            csv.Close();
        }

        private static string ChekAndGetParametr(object a)
        {
            if (a == null)
            {
                //a.ToString();
                a = "";
            }
            return a.ToString();
        }

        private static string GetContactList(string timeOffset)
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
