using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class HoursOfFacility
    {
        public int Id { get; set; }
        [Display(Name = "Day of the Week")]
        public int WeekDay { get; set; }
        [Display(Name = "Hours of Operation")]
        public string? HoursOfOperation { get; set; } // 8am - 12pm
        [Display(Name = "Office Hours")]
        public string? OfficeHours { get; set; }
        [NotMapped]
        public string WeekDayName
        {
            get
            {
                return GetDayOfWeekName();
            }
        }

        private string GetDayOfWeekName()
        {
            var dayOfWeekname = (DayOfWeek)WeekDay;
            return dayOfWeekname.ToString();
        }
    }
}
