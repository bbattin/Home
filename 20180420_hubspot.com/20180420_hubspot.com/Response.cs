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
        public long AddedAt { get; set; }

        [JsonProperty(PropertyName = "vid")]
        public int Vid { get; set; }


        //public string CanonicalVid { get; set; }
        //public List<object> MergedVids { get; set; }

        [JsonProperty(PropertyName = "portal-id")]
        public int PortalId { get; set; }

        //public bool IsContact { get; set; }
        //public string ProfileToken { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public List<Property> Properties { get; set; }

        //public List<object> FormSubmissions { get; set; }
        //public List<IdentityProfile> IdentityProfiles { get; set; }
        //public List<object> MergeAudits { get; set; }
    }
}
