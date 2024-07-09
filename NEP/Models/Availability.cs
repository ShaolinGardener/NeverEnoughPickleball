using System;
using System.Collections.Generic;

namespace NEP.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public string FacilityName { get; set; }
        public string FacilityContactEmail { get; set; }
        public string MondayHours { get; set; }
        public string TuesdayHours { get; set; }
    }

}
