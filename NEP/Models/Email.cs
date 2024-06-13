using NEP.ServiceManager;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace NEP.Models
{
    public class Email
    {
        public Guid Id { get; set; }
        [Required]
        public string FromAddress { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }



        public async Task<string> SendMail(string addressTo)
        {
            var emailService = new EmailService();
            try
            {
                await emailService.SendHtmlEmail("contact@neverenoughpickleball.com", "Test Email", "<h1>Hello!</h1><p>This is a test email.</p>");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Success";

        }
    }
}
