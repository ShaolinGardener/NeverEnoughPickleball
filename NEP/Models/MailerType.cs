namespace NEP.Models
{
    public enum MailerTypeEnums
    {
        Message=1,
        Registration,
        CorporateSolicitation,
        MemberSolicitation,
        Newsletter,
        Event,
        RetailerAndManufacturer
    }
    public class MailerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MailerSignatureId { get; set; }
    }
}
