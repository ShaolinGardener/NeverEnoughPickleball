using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class HoursOfDelivery
    {
        public int Id { get; set; }
        [Display(Name = "Day of the Week")]
        public int WeekDay { get; set; }
        [Display(Name = "Hours of Operation")]
        public string HoursOfOperation { get; set; }
        [Display(Name = "Office Hours")]
        public string OfficeHours { get; set; }
        public DiningFacility DiningFacility { get; set; }
        [ForeignKey("DiningFacilityId")]
        public int DiningFacilityId { get; set; }
        [Display(Name = "Delivery Fee")]
        public double Fee { get; set; }

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
        [NotMapped]
        public string FeeInDollars => Fee.ToString("C");
    }
}
