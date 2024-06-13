using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace NEP.Models
{
    public class Mailer
    {

    public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("MailerType")]
        [Column("MailerTypeId")]
        public int MailerTypeId { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string Event { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
