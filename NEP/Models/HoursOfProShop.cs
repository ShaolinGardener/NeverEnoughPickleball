using System.ComponentModel.DataAnnotations.Schema;

namespace NEP.Models
{
    public class HoursOfProShop
    {
        public int Id { get; set; }
        public int WeekDay { get; set; }
        public string HoursOfOperation { get; set; }
        public string OfficeHours { get; set; }
        public ProShop ProShop{ get; set; }
        [ForeignKey("ProShopId")]
        public int ProShopId { get; set; }        
    }
}
