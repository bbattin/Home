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
        public ValueJson Firstname { get; set; }

        [JsonProperty(PropertyName = "lastmodifieddate")]
        public ValueJson Lastmodifieddate { get; set; }

        [JsonProperty(PropertyName = "company")]
        public ValueJson Company { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public ValueJson Lastname { get; set; }
    }

    class ValueJson
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

}
