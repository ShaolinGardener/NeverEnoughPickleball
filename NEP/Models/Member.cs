using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NEP.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        [Display(Name = "Occupation Details")]
        public string OccupationDetails { get; set; }

        [Required]
        public string Languages { get; set; }

        [Required]
        [Display(Name = "Parent/Guardian")]
        public string ParentGuardian { get; set; }

        [Required]
        public string Relationship { get; set; }

        [Required]
        [Display(Name = "How Did You Hear About Us?")]
        public string HearAboutUs { get; set; }
    }
}
