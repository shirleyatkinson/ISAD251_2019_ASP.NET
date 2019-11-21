using System;
using System.Collections.Generic;

namespace ISAD251_2019_ASP.Models
{
    public partial class ShStatus
    {
        public ShStatus()
        {
            ShRequest = new HashSet<ShRequest>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ShRequest> ShRequest { get; set; }
    }
}
