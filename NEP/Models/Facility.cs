using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Address? Address { get; set; }
        public Guid? AddressId { get; set; }
        [Display(Name = "Contact Name")]
        public string? ContactName { get; set; }
        [Display(Name = "Contact Email")]
        public string? ContactEmail { get; set; }
        public string? Phone { get; set; }
        public string? Url { get; set; }
        [Display(Name="Public Access")]
        public bool IsPublic { get; set; }
        [Display(Name="Never Enough Pickleball Partner")]
        public bool NEPPartner { get; set; }
        [NotMapped]
        public double DistanceInMiles { get; set; }


        #region Courts
        [Display(Name = "Number of Courts")]
        public int NumberOfCourts { get; set; }
        public List<Court> Courts { get; set; }
        [Display(Name = "Court Thumbnail")]
        public int? FacilityCourtIconImage { get; set; }
        [Display(Name="Court Image 1")]
        public int? CourtImage1 { get; set; }
        [Display(Name = "Court Image 2")] 
        public int? CourtImage2 { get; set; }
        [Display(Name = "Court Image 3")]
        public int? CourtImage3 { get; set; }
        [Display(Name = "Court Image 4")]
        public int? CourtImage4 { get; set; }
        [Display(Name = "Court Image 5")]
        public int? CourtImage5 { get; set; }
        [Display(Name = "Court Icon Image")]
        public int? CourtIconImage { get; set; }
        #endregion

        #region Associated Costs
        [Display(Name = "Free")]
        public bool IsFree { get; set; }
        
        public double? Fee { get; set; }
        [Display(Name = "Has Memberships")]
        public bool Memberships { get; set; }
        [Display(Name = "Membership Fee")]
        public double? MembershipFee { get; set; }
        [Display(Name = "Membership Discount Amount")]
        public double? MembershipDiscountFee { get; set; }
        [Display(Name = "Has Reservations")]
        public bool Reservations { get; set; }
        [Display(Name = "Allows Drop Ins")]
        public bool DropIns { get; set; }
        [Display(Name = "Never Enough Pickleball Membership Discount")]
        public string? NEPMembershipDiscount { get; set; }
        #endregion

        #region Events
        [Display(Name = "Tournaments")]
        public bool hasTournaments { get; set; }
        [Display(Name = "League Play")]
        public bool hasLeaguePlay { get; set; }
        [Display(Name = "Party Booking")]
        public bool hasPartyBooking { get; set; }
        [Display(Name = "Special Events")]
        public bool hasSpecialEvents { get; set; }
        [Display(Name = "Corporate Retreats")]
        public bool hasCorporateRetreats { get; set; }
        #endregion

        //#region Hours Of Play
        //public List<HoursOfPlay> HoursOfPlay { get; set; }
        //#endregion

        #region Amenities
        [Display(Name = "Restrooms")]
        public bool RestRooms { get; set; }
        [Display(Name = "Water Fountains")]
        public bool WaterFountain { get; set; }
        public bool Showers { get; set; }
        [Display(Name = "Locker Rooms")]
        public bool LockerRooms { get; set; }
        [Display(Name = "Car Charging")]
        public bool CarCharge { get; set; }
        [Display(Name = "Playground")]
        public bool Playground { get; set; }
        [Display(Name = "Picnic Area")]
        public bool Picnic { get; set; }
        public bool Parking { get; set; }
        public bool Lights { get; set; }
        [Display(Name = "Dedicated Pickleball")]
        public bool Dedicated { get; set; }

        #endregion

        #region Vending Machines
        [Display(Name = "Snack Machines")]
        public bool Snacks { get; set; }
        [Display(Name = "Beverage Machines")]
        public bool Beverages { get; set; }
        #endregion

        #region Food and Beverage
        public List<DiningFacility> DiningFacilities { get; set; }
        [Display(Name = "Beverages (Other Source)")]
        public bool BeverageOther { get; set; }
        #endregion

        #region Pro Shop
        [Display(Name = "Pro Shop")]
        public bool HasProShop { get; set; }
        public ProShop? ProShop{ get; set; }
        [ForeignKey("ProShopId")]
        public int? ProShopId { get; set; }
        #endregion
        
    }
}
