using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Migrations;
using NEP.Models;
using NEP.ServiceManager;

namespace NEP.Controllers
{
    public class ContactController : Controller
    {
        private readonly NEPContext _context;
        public ContactController(NEPContext nepContext)
        {
            _context = nepContext;
        }

        [HttpPost]
        public async Task<string> Index(string name, string email, string subject, string body)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "NONE PROVIDED";
            }
            if (string.IsNullOrEmpty(email))
            {
                email = "NONE PROVIDED";
            }

            NEP.Models.Email guestEmail = new NEP.Models.Email() { Name = name, FromAddress = email, Subject = subject, Body = body, DateCreated = DateTime.Now, IsNew = true, IsDeleted = false };

            // log what we've received
            var emailAdded = _context.Emails.Add(guestEmail);
            if (emailAdded.State == EntityState.Added)
            {
                _context.SaveChanges();
            }

            // send email to NEP
            body = "<pre>From " + name + " <" + email + "> \n" + body + "</pre>";
            EmailService emailService = new EmailService();
            var retVal = await emailService.SendHtmlEmail("contact@neverenoughpickleball.com", subject, body);

            // send reply to user
            await SendMessageEmail(email);
            return retVal;
        }

        private async Task SendMessageEmail(string email)
        {
            var mailer = _context.Mailers.Where(u => (MailerTypeEnums)u.MailerTypeId == MailerTypeEnums.Message).SingleOrDefault();
            if (mailer != null)
            {
                string emailContent = mailer.Content;
                string emailSubject = mailer.Subject;

                var mailerSignature = _context.MailerSignatures.Where(u => u.Name == "Main").SingleOrDefault();
                if (mailerSignature != null)
                {
                    emailContent = emailContent.Replace("{{signature}}", mailerSignature.Content);
                }

                EmailService emailsvc = new EmailService();
                var result = await emailsvc.SendHtmlEmail(email, emailSubject, emailContent);
            }
        }

        [HttpPost]
        public async void SendCorporateEmail(string email)
        {
            string[] localEmail = new string[1];
            if (email.Contains(","))
            {
                localEmail = email.Split(',');
            }
            else
            {
                localEmail[0] = email;
            }

            var emailSuccess = string.Empty;
            var emailFail = string.Empty;
            var comma = string.Empty;
            var mailer = _context.Mailers.Where(u => (MailerTypeEnums)u.MailerTypeId == MailerTypeEnums.CorporateSolicitation).SingleOrDefault();
            if (mailer != null)
            {
                string emailContent = mailer.Content;
                string emailSubject = mailer.Subject;

                var mailerSignature = _context.MailerSignatures.Where(u => u.Name == "Main").SingleOrDefault();
                if (mailerSignature != null)
                {
                    emailContent = emailContent.Replace("{{signature}}", mailerSignature.Content);
                }

                foreach (var le in localEmail)
                {
                    try
                    {
                        EmailService emailsvc = new EmailService();
                        var result = await emailsvc.SendHtmlEmail(le.Trim(), emailSubject, emailContent);
                        emailSuccess = emailSuccess + comma + le.Trim();
                        comma = ",";
                    }
                    catch (Exception ex)
                    {
                        emailFail = emailFail+le.Trim() + ": " + ex.Message + "<br>";
                    }
                }

                EmailService resultEmail = new EmailService();
                var result2 = await resultEmail.SendHtmlEmail("contact@neverenoughpickleball.com", "SendEmail Results: Corporate", "Success:<br>" + emailSuccess + "<br><br>Failures:<br>" + emailFail);
            }
        }

        [HttpPost]
        public async void SendRetailerEmail(string email)
        {
            string[] localEmail = new string[1];
            if (email.Contains(","))
            {
                localEmail = email.Split(',');
            }
            else
            {
                localEmail[0] = email;
            }

            var emailSuccess = string.Empty;
            var emailFail = string.Empty;
            var comma = string.Empty;
            var mailer = _context.Mailers.Where(u => (MailerTypeEnums)u.MailerTypeId == MailerTypeEnums.RetailerAndManufacturer).SingleOrDefault();
            if (mailer != null)
            {
                string emailContent = mailer.Content;
                string emailSubject = mailer.Subject;

                var mailerSignature = _context.MailerSignatures.Where(u => u.Name == "Main").SingleOrDefault();
                if (mailerSignature != null)
                {
                    emailContent = emailContent.Replace("{{signature}}", mailerSignature.Content);
                }

                foreach (var le in localEmail)
                {
                    try
                    {
                        EmailService emailsvc = new EmailService();
                        var result = await emailsvc.SendHtmlEmail(le.Trim(), emailSubject, emailContent);
                        emailSuccess = emailSuccess + comma + le.Trim();
                        comma = ",";
                    }
                    catch (Exception ex)
                    {
                        emailFail = emailFail+ le.Trim() + ": " + ex.Message + "<br>";
                    }
                }

                EmailService resultEmail = new EmailService();
                var result2 = await resultEmail.SendHtmlEmail("contact@neverenoughpickleball.com", "SendEmail Results: Retailer", "Success:<br>" + emailSuccess + "<br><br>Failures:<br>" + emailFail);

            }
        }

        [HttpGet]
        public PartialViewResult Signature()
        {
            return new PartialViewResult();
        }

        [HttpGet]
        public async void SendTestHTMLEmail()
        {
            var body = "<html><body><h3>Thanks for your interest in Never Enough Pickleball&reg;</h3>" +
                "<br><p>We excited to, with your help, grow the sport of Pickleball.</p> <img src=\"http://neverenoughpickleball.com/QrCoder/GetSiteQRCode/#\" width=\"200\">" +
                "[email signature here]" +
                "</body></html>";

            EmailService emailService = new EmailService();
            var retVal = await emailService.SendHtmlEmail("contact@neverenoughpickleball.com", "test html email", body);

        }
    }
}



//string emailContent = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    " +
//    "<meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" con" +
//    "tent=\"width=device-width, initial-scale=1.0\">\r\n    " +
//    "<title>Never Enough Pickleball - Membership</title>\r\n    " +
//    "<link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Roboto:100,300,400,400italic,700'>\r\n    " +
//    "<link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Patua+One:100,300,400,400italic,700'>\r\n    " +
//    "<link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Lato:400,400italic,700,700italic,900'>\r\n    " +
//    "<link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Poppins:100,300,400,400italic,500,700,700italic'>\r\n\r\n    " +
//    "<!-- CSS -->\r\n    <link rel='stylesheet' href='https://neverenoughpickleball.com/gsm/css/global.css'>\r\n    " +
//    "<link rel='stylesheet' href='https://neverenoughpickleball.com/gsm/content/gsmservice/css/structure.css'>\r\n    " +
//    "<link rel='stylesheet' href='https://neverenoughpickleball.com/gsm/content/gsmservice/css/gsmservice.css'>\r\n    " +
//    "<link rel='stylesheet' href='https://neverenoughpickleball.com/gsm/content/gsmservice/css/custom.css'>\r\n    <style>\r\n   " +
//    " p{\r\n         font-family:Poppins;\r\n         color:#2a2a2a\r\n    }\r\n    </style>\r\n</head>\r\n<body>\r\n   " +
//    " <img src=\"https://neverenoughpickleball.com/gsm/content/gsmservice/images/NEP-logo.png\" style=\"width:150px;margin-left:30px\" " +
//    "alt=\"Never Enough Pickleball, Inc\">\r\n    \r\n    <div style=\"font-family:Poppins;margin:30px\">\r\n        " +
//    "<h2>Never Enough Pickleball&reg; <span style=\"color:#ff6801\">thanks you for your interest!</span></h2>\r\n        " +
//    "<p>We will get back to you as soon as possible.</p><p style=\"font-family:Poppins;color:#2a2a2a\">We have big plans for bringing all that Pickleball has to offer to \r\n        " +
//    "the masses and we're excited that you've chosen to accompany us on that journey. \r\n        " +
//    "</p>\r\n        <p>As a charitable 501c3 organization, we rely on donations from the public. In particular, we appreciate donations from our\r\n   " +
//    "     members, as we know that they are in agreement that our cause is worthwhile. To that end we welcome any contribution you can afford to make. " +
//    "Thanks in advance.\r\n        </p>\r\n        <p><a href=\"https://www.zeffy.com/en-US/donation-form/2d9d06ed-abe7-48d3-a859-1f65e3db7290\" " +
//    "target=\"_blank\">\r\n        <img src=\"https://neverenoughpickleball.com/images/buttons/slider_donate_static_btn.png\" style=\"border:none\"" +
//    " alt=\"Donate\">\r\n        </a>\r\n        </p>\r\n        <p>In addition, we also appreciate, and are building a program of rewarding, " +
//    "members for spreading the word. If you have not already done so, please consider becoming a member. It's free and we are working diligently to get the rewards program up and running.        " +
//    "<br>\r\n       " +
//    " <img src=\"https://neverenoughpickleball.com/QrCoder/GetSiteQRCode/\" style=\"width:150px\"><br>\r\n       " +
//    " <a href=\"https://neverenoughpickleball.com/#membership\">Become a Member!</a>\r\n        </p>\r\n      " +
//    "  <p>In closing, we once again appreciate your interest in our efforts to grow the sport of Pickleball. Please stay \r\n     " +
//    "   tuned as we have a great many features in the pipeline. \r\n        \r\n        <p><br>Thanks,<br>The Team<br>Never Enough Pickleball&reg;<br>\r\n  " +
//    "      407-574-7411\r\n</body>\r\n</html>";