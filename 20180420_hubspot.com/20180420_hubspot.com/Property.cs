using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180420_hubspot.com
{
    class Property
    {
        [JsonProperty(PropertyName = "firstname")]
        public Firstname Firstname { get; set; }

        [JsonProperty(PropertyName = "lastmodifieddate")]
        public Lastmodifieddate Lastmodifieddate { get; set; }

        [JsonProperty(PropertyName = "company")]
        public Company Company { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public Lastname Lastname { get; set; }
    }

    class Firstname
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

    class Lastmodifieddate
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

    class Company
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

    class Lastname
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
