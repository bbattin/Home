using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180420_hubspot.com
{
    class AssociatedCompany
    {
        //[JsonProperty(PropertyName = "portal-id?")]
        public int Id { get; set; }

        //[JsonProperty(PropertyName = "title?")]
        public string Name { get; set; }

        //[JsonProperty(PropertyName = "page-url?")]
        public string Website { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string City { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string State { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string Zip { get; set; }

        //[JsonProperty(PropertyName = "?")]
        public string Phone { get; set; }
    }
}
