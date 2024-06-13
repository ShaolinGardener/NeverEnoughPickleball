using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NEP.Models
{
    public class CalendarNotification
    {
        [Key]
        public Guid UID { get; set; }
        public string Name { get; set; }
        [DisplayName("List of Attendees' Emails separated by commas")]
        public IEnumerable<Attendee> Attendees { get; set; }
        [DisplayName("Start Date/Time (EST)")]
        public DateTime StartDateTime { get; set; }
        [DisplayName("End Date/Time (EST)")]
        public DateTime EndDateTime { get; set; }
        [DisplayName("Your Email")]
        public string CreatorEmail { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }

    public class Attendee
    {
        [Key]
        public int Id { get; set; }
        public string AttendeeName { get; set; }
        public string AttendeeEmail { get; set; }
    }
}
