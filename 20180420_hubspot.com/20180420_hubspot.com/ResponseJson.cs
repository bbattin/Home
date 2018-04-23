using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180420_hubspot.com
{
    class ResponseJson
    {
        public List<Response> Responses { get; set; }
        public bool HasMore { get; set; }
        public int VidOffset { get; set; }
        public long TimeOffset { get; set; }
    }
}
