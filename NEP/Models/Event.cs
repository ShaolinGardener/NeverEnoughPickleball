namespace NEP.Models
{
    public class Event
    {
public Guid Id { get; set; }
public string Name { get; set; }
        public DateTime EventDateTime { get; set; }
        //public bool IsPaid { get; set; }
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
        public double Fee { get; set; }
        public double MembershipDiscountFee { get; set; }
    }
}
