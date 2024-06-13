using GoogleApi.Entities.Maps.Directions.Response;
using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Migrations;
using NEP.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace NEP.Controllers
{
    public class CalendarController : Controller
    {
        private readonly NEPContext _context;
        public CalendarController(NEPContext nepContext)
        {
            _context = nepContext;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name,StartDateTime,EndDateTime,Location,Description,CreatorEmail")] CalendarNotification calendarNotification,string Attendees)
        {
            calendarNotification.UID= Guid.NewGuid();
            var atts = new List<Attendee>();
            atts.Add(new Attendee() { AttendeeEmail = calendarNotification.CreatorEmail, AttendeeName = "System Generated" });
            var attendees = Attendees.Split(",");
            foreach (var a in attendees)
            {
                atts.Add(new Attendee() { AttendeeEmail = a.Trim(), AttendeeName = "System Generated" });
            }
            _context.Attendees.AddRange(atts);

            calendarNotification.Attendees = atts;
            _context.CalendarNotifications.Add(calendarNotification);
            _context.SaveChanges();
            SendCalendarEvent(calendarNotification);

            return View(calendarNotification);
        }

        public void SendCalendarEvent(CalendarNotification calendarNotification)
        {
            MailMessage message = new MailMessage();
            var smtpClient = new SmtpClient
            {
                Host = "mail.neverenoughpickleball.com", // "mail5019.site4now.net", // "smtp.office365.com",
                Port = 25, //465, // 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("contact@neverenoughpickleball.com", "210Kamen7311#")
            };
            //message.To.Add(calendarNotification.CreatorEmail);
            foreach (var att in calendarNotification.Attendees)
            {
                message.To.Add(att.AttendeeEmail);
            }
            message.From = new MailAddress("contact@neverenoughpickleball.com", "Never Enough Pickleball, Inc");
            message.Subject = calendarNotification.Name;
            message.Body = "<h3>You have been invited to attend a meeting with Never Enough Pickleball&reg;. The details are as follows:</h3>" + calendarNotification.Description;
            message.IsBodyHtml = true;

            List<iCalendar> iCals = new List<iCalendar>();
            iCals.Add(new iCalendar
            {
                EventStartDateTime = Convert.ToDateTime(calendarNotification.StartDateTime),
                EventEndDateTime = Convert.ToDateTime(calendarNotification.EndDateTime),
                UID = Guid.NewGuid().ToString(),
                EventDescription = calendarNotification.Description,
                EventLocation = calendarNotification.Location,
                EventSummary = calendarNotification.Name,
                Attendees=calendarNotification.Attendees.ToList(),                
                AlarmTrigger = "30",
                AlarmRepeat = "2",
                AlarmDuration = "15",
                AlarmDescription = "Upcoming Meeting: " + calendarNotification.Name
            });
            List<string> calendars = iCalendar.iCals(iCals);
            int i = 1;
            foreach (string iCal in calendars)
            {
                var calendarBytes = Encoding.UTF8.GetBytes(iCal);
                MemoryStream ms = new MemoryStream(calendarBytes);
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, String.Format("invite{0}.ics", i), "text/calendar");
                message.Attachments.Add(attachment);
                smtpClient.Send(message);
                i++;
            }            
        }
    }
}
