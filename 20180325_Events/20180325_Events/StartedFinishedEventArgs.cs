using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180325_Events
{
    class StartedFinishedEventArgs : EventArgs
    {
        public StartedFinishedEventArgs()
        {
            CreatedDate = DateTime.Now;
        }

      

         public DateTime CreatedDate { get; private set; }
         public DateTime FinishDate { get; set; }

    }
}
