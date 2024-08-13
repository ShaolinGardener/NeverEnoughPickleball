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

        [Required(ErrorMessage = "Mobile Number is required", AllowEmptyStrings = false)]
        [Phone(ErrorMessage = "Invalid Mobile Number")]
        public string Phone { get; set; } = string.Empty;


        [Required(ErrorMessage = "First Name is required", AllowEmptyStrings = false)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required", AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zipcode is required", AllowEmptyStrings = false)]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Member Type is required", AllowEmptyStrings = false)]
        public string MemberType { get; set; } = string.Empty;
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
        }
        public User(Guid id, string? userName, bool isActive, string phone, string firstName, string lastName, string email, string password, string zipCode, string memberType, DateTime dateCreated, Guid? referredById, bool isNewsletter, bool isRegistered, Guid? skillLevelId, string? skillLevelIsVerified, DateTime dOB, Guid? addressId, List<Mailer>? mailers, Address? address, NEPContext context)
        {
            Id = id;
            UserName = userName;
            IsActive = isActive;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            ZipCode = zipCode;
            MemberType = memberType;
            DateCreated = dateCreated;
            ReferredById = referredById;
            IsNewsletter = isNewsletter;
            IsRegistered = isRegistered;
            SkillLevelId = skillLevelId;
            SkillLevelIsVerified = skillLevelIsVerified;
            DOB = dOB;
            AddressId = addressId;
            Mailers = mailers;
            Address = address;
            _context = context;
        }
        public User () { }
    }



}
