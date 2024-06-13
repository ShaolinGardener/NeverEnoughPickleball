using System.Net.Mail;
using System.Net;
using System.Text;

namespace NEP.ServiceManager
{
    public class EmailService
    {
        public async Task<string> SendHtmlEmail(string toEmail, string subject, string htmlContent)
        {
            try
            {
                var fromAddress = new MailAddress("contact@neverenoughpickleball.com", "NEP Support");
                var toAddress = new MailAddress(toEmail);
                var smtpClient = new SmtpClient
                {
                    Host = "mail5019.site4now.net", // "smtp.office365.com",
                    Port = 25, //465, // 587,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("contact@neverenoughpickleball.com", "210Kamen7311#")
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = htmlContent,
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8
                })
                {
                    await smtpClient.SendMailAsync(message);
                }

                return "Sent";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
