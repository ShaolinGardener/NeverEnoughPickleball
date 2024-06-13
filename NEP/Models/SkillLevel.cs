using System.ComponentModel.DataAnnotations;

namespace NEP.Models
{
    public class SkillLevel
    {
        public Guid Id { get; set; }
        [Required]
        public string LevelName { get; set; }
        [Required]
        public int RankSequence { get; set; }
    }
}
