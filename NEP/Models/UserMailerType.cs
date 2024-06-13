using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class UserMailerType
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        [Column("UserId")]
        public Guid UserId { get; set; }
        [ForeignKey("MailerType")]
        [Column("MailerTypeId")]
        public int MailerTypeId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
