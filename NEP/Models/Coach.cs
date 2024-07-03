namespace NEP.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }

        public CoachSocialMedia CoachSocialMedia { get; set; }
    }
}
