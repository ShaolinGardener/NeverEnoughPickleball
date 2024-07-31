using NEP.Data;
using QRCoder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;


namespace NEP.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string ZipCode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string MemberType { get; set; }
        
        [Phone]
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string Phone { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }

        [ForeignKey("User")]
        [Column("ReferredById")]
        public Guid? ReferredById { get; set; }
        public bool IsNewsletter { get; set; }
        public bool IsRegistered { get; set; }
        [ForeignKey("SkillLevel")]
        public Guid? SkillLevelId { get; set; }

        public string? SkillLevelIsVerified { get; set; }
        public DateTime DOB { get; set; }
        [ForeignKey("Address")]
        [Column("AddressId")]
        public Guid? AddressId { get; set; }
        [NotMapped]
        public List<Mailer>? Mailers { get; set; }
        public Address? Address { get; set; }

        private readonly NEPContext _context;
        public User(NEPContext nepContext)
        {
            _context = nepContext;
            Address = nepContext.Addresses.Where(a => a.Id == AddressId).FirstOrDefault();
        }
    }



}
