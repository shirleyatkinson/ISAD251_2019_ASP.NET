using System;
using System.Collections.Generic;

namespace ISAD251_2019_ASP.Models
{
    public partial class ShModule
    {
        public ShModule()
        {
            ShRequest = new HashSet<ShRequest>();
        }

        public int ModuleId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

        public virtual ICollection<ShRequest> ShRequest { get; set; }
    }
}
