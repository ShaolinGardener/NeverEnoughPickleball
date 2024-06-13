using NuGet.Protocol.Core.Types;

namespace NEP.Models
{
    public class FacilityDTO
    {
        public int FacilityId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Lights { get; set; } = "off.png";
        public string CarCharge { get; set; } = "off.png";
        public string Fee { get; set; } = "off.png";
        public string Food { get; set; } = "off.png";
        public string Lockers { get; set; } = "off.png";
        public string Park { get; set; } = "off.png";
        public string Parking { get; set; } = "off.png";
        public string Playground { get; set; } = "off.png";
        public string Picnic { get; set; } = "off.png";
        public string Proshop { get; set; } = "off.png";
        public string Restrooms { get; set; } = "off.png";
        public string Shower { get; set; } = "off.png";
        public string Tournaments { get; set; } = "off.png";
        public string WaterFountain { get; set; } = "off.png";
        public string Thumbnail { get; set; }
        public string OrganizationThumbnail { get; set; }
        public string CourtCount { get; set; }
        public string SurfaceType { get; set; }
        public string Dedicated { get; set; }
        public string PermLines { get; set; }
        public string PermNets { get; set; }
        public CourtColors CourtColors { get; set; }
        public string Day1 { get; set; } = "off.png";
        public string Day2 { get; set; } = "off.png";
        public string Day3 { get; set; } = "off.png";
        public string Day4 { get; set; } = "off.png";
        public string Day5 { get; set; } = "off.png";
        public string Day6 { get; set; } = "off.png";    
        public string Day7 { get; set; } = "off.png";
        public double DistanceInMiles { get; set; }
    }
}
