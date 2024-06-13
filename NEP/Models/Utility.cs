using Microsoft.AspNetCore.Mvc.Rendering;

namespace NEP.Models
{
    public class Utility
    {
        public static SelectList GetWeekDaysSelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem("Sunday", "0"));
            items.Add(new SelectListItem("Monday", "1"));
            items.Add(new SelectListItem("Tuesday", "2"));
            items.Add(new SelectListItem("Wednesday", "3"));
            items.Add(new SelectListItem("Thursday", "4"));
            items.Add(new SelectListItem("Friday", "5"));
            items.Add(new SelectListItem("Saturday", "6"));
            SelectList weekdays = new SelectList(items);
            return weekdays;
        }

        public static SelectList GetPlayerRankingSelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem("All", "All"));
            items.Add(new SelectListItem("1.0-2.0", "1.0-2.0"));
            items.Add(new SelectListItem("2.5", "2.5"));
            items.Add(new SelectListItem("3.0", "3.0"));
            items.Add(new SelectListItem("3.5", "3.5"));
            items.Add(new SelectListItem("4.0", "4.0"));
            items.Add(new SelectListItem("4.5", "4.5"));
            items.Add(new SelectListItem("5.0", "5.0"));
            items.Add(new SelectListItem("5.5+", "5.5+"));
            SelectList rankings = new SelectList(items);
            return rankings;
        }
    }
}
