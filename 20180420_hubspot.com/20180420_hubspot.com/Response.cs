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
        public int Vid { get; set; }
        public string CanonicalVid { get; set; }
        public List<object> MergedVids { get; set; }
        public int PortalId { get; set; }
        public bool IsContact { get; set; }
        public string ProfileToken { get; set; }
        public List<Property> Properties { get; set; }
        public List<object> FormSubmissions { get; set; }
        public List<IdentityProfile> IdentityProfiles { get; set; }
        public List<object> MergeAudits { get; set; }
    }
}
