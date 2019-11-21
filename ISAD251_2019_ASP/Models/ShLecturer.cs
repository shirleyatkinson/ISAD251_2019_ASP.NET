using System;
using System.Collections.Generic;

namespace ISAD251_2019_ASP.Models
{
    public partial class ShLecturer
    {
        public int LecturerId { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
