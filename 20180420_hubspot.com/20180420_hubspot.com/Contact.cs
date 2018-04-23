using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180420_hubspot.com
{
    class Contact
    {
        //[JsonProperty(PropertyName = "vid")]
        public int Vid { get; set; }

        //[JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        //[JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }

        //[JsonProperty(PropertyName = "lastmodifieddate?")]
        public string Lifecyclestage { get; set; }

        //[JsonProperty(PropertyName = "company")]
        public AssociatedCompany AssociatedCompany { get; set; }
                
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
