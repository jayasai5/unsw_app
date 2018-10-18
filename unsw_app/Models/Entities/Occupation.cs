using System;

namespace unsw_app.Models.Entities
{
    public class Occupation
    {
        public int OccupationId { get; set; }
        public virtual Patient patient{ get;set;}
        public string OccupationType { get; set; }
        public DateTime OcupationTime { get; set; }
    }
}