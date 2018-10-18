using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unsw_app.Models.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public virtual List<Occupation> Occupations { get; set;}
    }
}
