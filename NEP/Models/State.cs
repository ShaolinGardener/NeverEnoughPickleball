using System.ComponentModel.DataAnnotations;

namespace NEP.Models
{
    public class State
    {
        public int Id { get; set; }
        [Display(Name="State Name")]
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public List<Address> Addresses { get; set; }
    }
}
