using System.ComponentModel.DataAnnotations;

namespace NEP.Models
{
    public class CourtColors
    {
        public int Id { get; set; }
        public Court Court { get; set; }
        public int CourtId { get; set; }
        [Display(Name = "Out-of-Bounds Color")]
        public string OBColor { get; set; }
        [Display(Name = "Service Area Color")]
        public string CourtColor { get; set; }
        [Display(Name = "Kitchen Color")]
        public string KitchenColor { get; set; }
        [Display(Name = "Line Color")]
        public string LineColor { get; set; }
    }
}
