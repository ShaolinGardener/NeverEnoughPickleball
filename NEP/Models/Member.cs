using System;
using System.ComponentModel.DataAnnotations;

namespace NEP.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ScreenName { get; set; }

        public string CompanyOrOrganization { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Street { get; set; }

        public string AptSuiteNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PlayType { get; set; }
        public string UnofficialRating { get; set; }
        public string DuprRating { get; set; }
        public string UtprRating { get; set; }
        public string PaddleUsed { get; set; }

       
        public string PersonalBio { get; set; }

        
        public string VolunteerInterest { get; set; }
        public string PlayedState { get; set; }
        public string PlayedCity { get; set; }
        public string PlayedParkFacility { get; set; }

        public string AvailableFacilitiesName { get; set; }
        public string AvailableFacilitiesContactEmail { get; set; }
        public string HowDidYouHearAboutNEP { get; set; }
        public string SuggestionsForNEP { get; set; }
    }

}
