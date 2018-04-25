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
        public int Vid { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Lifecyclestage { get; set; }

        public string Company { get; set; }

        public int PortalId { get; set; } 

        //public AssociatedCompany AssociatedCompany { get; set; }
                
    }
}
