using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180420_hubspot.com
{
    class Response
    {
        
        [JsonProperty(PropertyName = "vid")]
        public int Vid { get; set; } = 0;


        [JsonProperty(PropertyName = "portal-id")]
        public int PortalId { get; set; } = 0;

  
        [JsonProperty(PropertyName = "properties")]
        public Property Properties { get; set; }

    }
}
