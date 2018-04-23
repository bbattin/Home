using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace _20180420_hubspot.com
{
    class Program
    {
        static void Main(string[] args)
        {
            string hapikey = UI.GetHapikey();
            string countContacts = UI.GetCountContacts();
            string url = "https://api.hubapi.com/contacts/v1/lists/recently_updated/contacts/recent?hapikey=" + hapikey + "&count=" + countContacts;
            WebClient client = new WebClient();
            var result = client.DownloadString(url);
            Console.Write(result);
            Console.ReadKey();
        }

        
    }
}
