using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Core.Forms.Models
{
    public class LoginModel
    {
        public string grant_type { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}
