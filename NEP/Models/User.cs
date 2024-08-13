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

        public string? UserName { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [Phone(ErrorMessage = "Invalid Mobile Number")]
        public string Phone { get; set; } = string.Empty;


        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Member Type is required")]
        public string MemberType { get; set; }
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
