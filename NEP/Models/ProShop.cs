using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class ProShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public List<HoursOfProShop> Hours { get; set; }
        public string? URL { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? MembershipDiscount { get; set; }
        public string? NEPMembershipDiscount { get; set; }
    }
}
