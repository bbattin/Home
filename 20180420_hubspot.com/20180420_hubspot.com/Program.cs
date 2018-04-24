using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace _20180420_hubspot.com
{
    class Program
    {
        static void Main(string[] args)
        {
            string hapikey = "demo";
            string countContacts = "10";
            string timeOffset = "1524480259611";
            string vidOffset = "5875024";
            string url = "https://api.hubapi.com/contacts/v1/lists/recently_updated/contacts/recent?hapikey=" + hapikey + "&count=" + countContacts + "&timeOffset=" + timeOffset + "&vidOffset=" + vidOffset;
            WebClient client = new WebClient();
            string result = client.DownloadString(url);
            Console.Write(result);
        
            ResponseJson responseJson = JsonConvert.DeserializeObject<ResponseJson>(result);
            Console.WriteLine();
            
            Console.WriteLine(responseJson.Responses.Count);

            writingInExcMethod();

            Console.ReadKey();
        }

        private static void writingInExcMethod()
        {
            try
            {
                Excel.Application ObjExcel = new Excel.Application();
                Excel.Workbook ObjWorkBook;
                Excel.Worksheet ObjWorkSheet;
                ObjWorkBook = ObjExcel.Workbooks.Add(Missing.Value);
                ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                ObjWorkSheet.Cells[3, 1] = "51";
                ObjWorkBook.SaveAs("log.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                
                ObjExcel.Quit();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Ошибка при составлении лога\n" + exc.Message);
            }
        }

    }
}
