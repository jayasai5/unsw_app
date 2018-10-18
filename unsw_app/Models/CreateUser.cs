using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unsw_app.Models
{
    public class CreateUser
    {
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
