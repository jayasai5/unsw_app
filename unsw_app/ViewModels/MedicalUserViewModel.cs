using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unsw_app.ViewModels
{
    public class MedicalUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool Activated { get; set; }
    }
}
