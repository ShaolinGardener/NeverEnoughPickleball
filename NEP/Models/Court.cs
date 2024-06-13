using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class Court
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Facility Facility { get; set; }
        [ForeignKey("FacilityId")]
        public int FacilityId { get; set; }
        [Display(Name = "Indoor")]
        public bool IsIndoor { get; set; }
        public string? Surface { get; set; }
        [Display(Name = "Permanent Nets")]
        public string? Nets { get; set; }
        [Display(Name = "Permanent Lines")]
        public string? Lines { get; set; }        
        public List<HoursOfPlay> HoursOfPlay { get;set; }
        public  CourtColors CourtColors { get; set; }
        [Display(Name="Preferred Player Minimum Ranking")]
        public string PreferredPlayerMinimumRanking { get; set; }
    }
}
