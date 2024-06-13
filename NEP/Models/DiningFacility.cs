using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class DiningFacility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<HoursOfFood> HoursOfFood { get; set; }
        [DefaultValue(false)]
        [Display(Name = "Dining Facility Type (Cafe, Food Truck, Cart)")]
        public string DiningFacilityType { get; set; } // food truck, concession, cafe, cart
        [Display(Name = "Dine In Available")]
        public bool DineIn { get; set; }
        [Display(Name = "Delivery Available")]
        public bool Delivery { get; set; }
        public List<HoursOfDelivery> HoursOfDelivery { get; set; }
        [Display(Name = "Beer and Wine")]
        public bool BeerAndWine { get; set; }
        [Display(Name = "Full Liquor")]
        public bool FullLiquor { get; set; }
        public bool Reservations { get; set; }
        public string? Phone { get; set; }
        public string? URL { get; set; }
        public Facility? Facility { get; set; }
        [ForeignKey("FacilityId")]
        public int FacilityId { get; set; }
        [Display(Name = "Menu URL")]
        public string? Menu { get; set; }
        [Display(Name = "Image 1")]
        public string? Image1 { get; set; }
        [Display(Name = "Image 2")]
        public string? Image2 { get; set; }
        [Display(Name = "Image 3")]
        public string? Image3 { get; set; }
    }
}
