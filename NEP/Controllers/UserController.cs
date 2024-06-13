using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Models;
using NEP.ServiceManager;

namespace NEP.Controllers
{
    public class UserController : Controller
    {
        private readonly NEPContext _context;
        public UserController(NEPContext nepContext)
        {
            _context = nepContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public string Register(string firstname, string lastname, string email, string phone, string zipcode, string? referred)
        {
            // check for exant user
            Guid? referredGuid = null;

            var user = _context.Users.Where(u => u.Email.ToLower() == email.ToLower()).SingleOrDefault();
            if (user == null)
            {
                if (string.IsNullOrEmpty(referred))
                {
                    referredGuid = null;
                }
                else
                {
                    try
                    {
                        referredGuid = new Guid(referred);
                        var extantuser = _context.Users.Where(u => u.Id == referredGuid.Value).SingleOrDefault();
                        if (extantuser == null)
                        {
                            referredGuid = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        referredGuid = null;
                    }
                }
                user = new User(_context) { FirstName = firstname, LastName = lastname, Email = email, Phone = phone,ZipCode = zipcode, DateCreated = DateTime.Now, IsActive = true, IsNewsletter = true, IsRegistered = true };
                if (referredGuid != null)
                {
                    user.ReferredById = referredGuid;
                }

                _context.Users.Add(user);
                _context.SaveChanges();


                SendUserMembershipEmail(email, user.Id.ToString());

                return "Your account has been created. Stay tuned as we add more features.";
            }

            return "Your account already exists. Stay tuned as we add more features.";
        }

        private async void SendUserMembershipEmail(string email, string userId)
        {
            var mailer = _context.Mailers.Where(u => (MailerTypeEnums)u.MailerTypeId == MailerTypeEnums.Registration).SingleOrDefault();
            if (mailer != null)
            {
                string emailContent = mailer.Content;
                string subject = mailer.Subject;

                var mailerSignature = _context.MailerSignatures.Where(u => u.Name == "Main").SingleOrDefault();
                if (mailerSignature != null)
                {
                    emailContent = emailContent.Replace("{{signature}}", mailerSignature.Content);
                }

                emailContent = emailContent.Replace("{{qrcode}}", userId);
                EmailService emailsvc = new EmailService();
                var result = await emailsvc.SendHtmlEmail(email, subject, emailContent);
            }

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
//    "<h2>Never Enough Pickleball&reg; <span style=\"color:#ff6801\">thanks you for registering!</span></h2>\r\n        " +
//    "<p style=\"font-family:Poppins;color:#2a2a2a\">We have big plans for bringing all that Pickleball has to offer to \r\n        " +
//    "the masses and we're excited that you've chosen to accompany us on that journey. \r\n        " +
//    "</p>\r\n        <p>As a charitable 501c3 organization, we rely on donations from the public. In particular, we appreciate donations from our\r\n   " +
//    "     members, as we know that they are in agreement that our cause is worthwhile. To that end we welcome any contribution you can afford to make. " +
//    "Thanks in advance.\r\n        </p>\r\n        <p><a href=\"https://www.zeffy.com/en-US/donation-form/2d9d06ed-abe7-48d3-a859-1f65e3db7290\" " +
//    "target=\"_blank\">\r\n        <img src=\"https://neverenoughpickleball.com/images/buttons/slider_donate_static_btn.png\" style=\"border:none\"" +
//    " alt=\"Donate\">\r\n        </a>\r\n        </p>\r\n        <p>In addition, we also appreciate, and are building a program of rewarding, " +
//    "members for spreading the word. The code and link below are unique \r\n        to your membership and can be\r\n        " +
//    "used to refer a friend. Doing so with this information will provide a means of referencing you as referrer. In the near future we'll \r\n       " +
//    " be rewarding those members that have the most referrals and the most associated contributions. <br>\r\n       " +
//    " <img src=\"https://neverenoughpickleball.com/QrCoder/GetUserQRCode/{{qrcode}}\" style=\"width:150px\"><br>\r\n       " +
//    " <a href=\"https://neverenoughpickleball.com/?userId={{qrcode}}\">Refer a Friend</a>\r\n        </p>\r\n      " +
//    "  <p>In closing, we once again appreciate your willingness to participate in our efforts to grow the sport of Pickleball. Please stay \r\n     " +
//    "   tuned as we have a great many features in the pipeline. \r\n        \r\n        <p><br>Thanks,<br>The Team<br>Never Enough Pickleball&reg;<br>\r\n  " +
//    "      407-574-7411\r\n</body>\r\n</html>";