using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class HoursOfPlay 
    {
        public int Id { get; set; }
        [Display(Name = "Day of the Week")]
        public int WeekDay { get; set; }
        [Display(Name = "Hours Available (ex. 8am-12pm)")]
        [NotMapped]
        public string WeekDayName
        {
            get
            {
               return  GetDayOfWeekName();
            }
        }

        private string GetDayOfWeekName()
        {
            var dayOfWeekname=  (DayOfWeek)WeekDay;
            return dayOfWeekname.ToString();
        }

        public string Hours  { get; set; }
        [Display(Name = "Fee to Play (Dollar Amount)")]
        public double Fee { get; set; }
        public Court Court { get; set; }
        [ForeignKey("CourtId")]
        public int CourtId { get; set; }
        [Display(Name = "Usage Type (ex. Open, Fee, Coaching, etc.)")]
        public string? UsageType { get; set; }
        [NotMapped]
        public string FeeInDollars => Fee.ToString("C"); 


    }
}
