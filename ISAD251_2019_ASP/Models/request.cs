using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_2019_ASP.Models
{
    public class request
    {
        public int RequestId { get; set; }
      
        public DateTime DateTime { get; set; }
        public string Room { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public string Problem { get; set; }
        public int ModuleId { get; set; }
        public int StatusId { get; set; }

        public virtual ShModule Module { get; set; }
        public virtual ShStatus Status { get; set; }
    }
}
