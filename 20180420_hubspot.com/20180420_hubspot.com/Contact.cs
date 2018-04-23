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
        [JsonProperty(PropertyName = "vid")]
        public int Vid { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string Lifecyclestage { get; set; }

        [JsonProperty(PropertyName = "company")]
        public string Associated_company { get; set; }

        [JsonProperty(PropertyName = "portal-id")]
        public int Company_id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "page-url")]
        public string Website { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string City { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string State { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string Zip { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
