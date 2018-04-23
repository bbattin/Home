using System;
using Newtonsoft.Json;
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
            string timeOffset = "1524480259611";
            string vidOffset = "5875024";
            string url = "https://api.hubapi.com/contacts/v1/lists/recently_updated/contacts/recent?hapikey=" + hapikey + "&count=" + countContacts + "&timeOffset=" + timeOffset + "&vidOffset=" + vidOffset;
            WebClient client = new WebClient();
            string result = client.DownloadString(url);
            Console.Write(result);
            //var contact = JsonConvert.DeserializeObject<Contact>(result);
            //Contact contact = JsonConvert.DeserializeObject<Contact>("{\"firstname\":\"NAME\"}");
            //Console.WriteLine(contact.Firstname, contact.Website, contact.Name);
            //Console.WriteLine(contact.Firstname);

            ResponseJson responseJson = JsonConvert.DeserializeObject<ResponseJson>(result);

            Console.ReadKey();
        }

    }
}
