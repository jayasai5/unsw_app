using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unsw_app.Models.Entities
{
    public class MedicalUser
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }
        public bool Activated { get; set; }
    }
}
