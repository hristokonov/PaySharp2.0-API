using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySharp.API.Models
{
    public class UserLoginModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
