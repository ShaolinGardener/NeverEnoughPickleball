using System.Text;

namespace NEP.Models
{
    public class iCalendar
    {

        public DateTime EventStartDateTime
        {
            get;
            set;
        }
        public DateTime EventEndDateTime
        {
            get;
            set;
        }
        public DateTime EventTimeStamp
        {
            get;
            set;
        }
        public DateTime EventCreatedDateTime
        {
            get;
            set;
        }
        public DateTime EventLastModifiedTimeStamp
        {
            get;
            set;
        }
        public List<Attendee> Attendees { get; set; }
        public string UID
        {
            get;
            set;
        }
        public string EventDescription
        {
            get;
            set;
        }
        public string EventLocation
        {
            get;
            set;
        }
        public string EventSummary
        {
            get;
            set;
        }
        public string AlarmTrigger
        {
            get;
            set;
        }
        public string AlarmRepeat
        {
            get;
            set;
        }
        public string AlarmDuration
        {
            get;
            set;
        }
        public string AlarmDescription
        {
            get;
            set;
        }
        public iCalendar()
        {
            EventTimeStamp = DateTime.Now;
            EventCreatedDateTime = EventTimeStamp;
            EventLastModifiedTimeStamp = EventTimeStamp;
        }

        public static List<string> iCals(List<iCalendar> iCals)
        {
            List<string> calendars = new List<string>();
            foreach (iCalendar iCal in iCals)
            {
                StringBuilder sb = new StringBuilder();
                //Calendar
                sb.AppendLine("BEGIN:VCALENDAR");
                sb.AppendLine("PRODID:-//Never Enough Pickleball Inc//Product Application//EN");
                sb.AppendLine("VERSION:2.0");
                sb.AppendLine("CALSCALE:GREGORIAN");
                sb.AppendLine("METHOD:REQUEST");
                sb.AppendLine("BEGIN:VTIMEZONE");
                sb.AppendLine("TZID:America/New_York");
                sb.AppendLine("X-LIC-LOCATION:America/New_York");
                sb.AppendLine("BEGIN:DAYLIGHT");
                sb.AppendLine("TZOFFSETFROM:-0500");
                sb.AppendLine("TZOFFSETTO:-0400");
                sb.AppendLine("TZNAME:EDT");
                sb.AppendLine("DTSTART:19700308T020000");
                sb.AppendLine("RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=2SU");
                sb.AppendLine("END:DAYLIGHT");
                sb.AppendLine("BEGIN:STANDARD");
                sb.AppendLine("TZOFFSETFROM:-0400");
                sb.AppendLine("TZOFFSETTO:-0500");
                sb.AppendLine("TZNAME:EST");
                sb.AppendLine("DTSTART:19701101T020000");
                sb.AppendLine("RRULE:FREQ=YEARLY;BYMONTH=11;BYDAY=1SU");
                sb.AppendLine("END:STANDARD");
                sb.AppendLine("END:VTIMEZONE");

                // begin the event
                sb.AppendLine("BEGIN:VEVENT");
                sb.AppendLine("DTSTART;TZID=America/New_York:" + toESTTime(iCal.EventStartDateTime));
                sb.AppendLine("DTEND;TZID=America/New_York:" + toESTTime(iCal.EventEndDateTime));
                sb.AppendLine("DTSTAMP;TZID=America/New_York:" + toUniversalTime(iCal.EventTimeStamp));
                sb.AppendLine("ORGANIZER;CN=Clay Stone:mailto:contact@neverenoughpickleball.com");
                sb.AppendLine("UID:" + iCal.UID);
                iCal.Attendees.ForEach(x =>
                    sb.AppendLine("ATTENDEE;CUTYPE=INDIVIDUAL;ROLE=REQ-PARTICIPANT;PARTSTAT=NEEDS-ACTION;RSVP=\r\n TRUE;CN=" +
                        x.AttendeeEmail + ";X-NUM-GUESTS=0:" + x.AttendeeEmail) //"\r\nX-MICROSOFT-CDO-OWNERAPPTID:1937106523"
                );

                sb.AppendLine("CREATED:" + toUniversalTime(iCal.EventCreatedDateTime));
                sb.AppendLine("DESCRIPTION:" + iCal.EventDescription);
                sb.AppendLine("X-ALT-DESC;FMTTYPE=text/html:" + iCal.EventDescription);
                sb.AppendLine("LAST-MODIFIED;TZID=America/New_York:" + toUniversalTime(iCal.EventLastModifiedTimeStamp));
                sb.AppendLine("LOCATION:" + iCal.EventLocation);
                sb.AppendLine("SEQUENCE:0");
                sb.AppendLine("STATUS:CONFIRMED");
                sb.AppendLine("SUMMARY:" + iCal.EventSummary);
                sb.AppendLine("TRANSP:OPAQUE");
                //Alarm
                sb.AppendLine("BEGIN:VALARM");
                sb.AppendLine("TRIGGER:" + String.Format("-PT{0}M", iCal.AlarmTrigger));
                sb.AppendLine("REPEAT:" + iCal.AlarmRepeat);
                sb.AppendLine("DURATION:" + String.Format("PT{0}M", iCal.AlarmDuration));
                sb.AppendLine("ACTION:DISPLAY");
                sb.AppendLine("DESCRIPTION:" + iCal.AlarmDescription);
                sb.AppendLine("END:VALARM");

                //close out the event and calendar
                sb.AppendLine("END:VEVENT");
                sb.AppendLine("END:VCALENDAR");
                calendars.Add(sb.ToString());
            }
            return calendars;
        }
        public static string toUniversalTime(DateTime dt)
        {
            string DateFormat = "yyyyMMddTHHmmssZ";
            return dt.ToUniversalTime().ToString(DateFormat);
        }

        public static string toESTTime(DateTime dt)
        {
            string DateFormat = "yyyyMMddTHHmmss";
            return dt.ToString(DateFormat);
        }
    }



}
