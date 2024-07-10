using System;

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
        public string WednesdayHours { get; set; }
        public string ThursdayHours { get; set; }
        public string FridayHours { get; set; }
        public string SaturdayHours { get; set; }
        public string SundayHours { get; set; }
        public string HolidayName { get; set; }
        public string HolidayHours { get; set; }
        public string ScheduledHolidays { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
