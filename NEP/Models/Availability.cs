using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace NEP.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public int CoachId { get; set; }

        [Required]
        public string FacilityName { get; set; }

        [Required]
        [EmailAddress]
        public string FacilityContactEmail { get; set; }

        public string MondayHours { get; set; }
        public string TuesdayHours { get; set; }
        public string WednesdayHours { get; set; }
        public string ThursdayHours { get; set; }
        public string FridayHours { get; set; }
        public string SaturdayHours { get; set; }
        public string SundayHours { get; set; }

        public DateTime? HolidayDate { get; set; }
        public string HolidayName { get; set; }
        public string HolidayHours { get; set; }
        public string ScheduledHolidays { get; set; }
        public string AdditionalNotes { get; set; }
        public bool IsStandard { get; set; }
        public bool IsUniqueToFacility { get; set; }

        [Column(TypeName = "jsonb")] // For PostgreSQL
        public string LocationsJson { get; set; }

        [NotMapped]
        public List<string> Locations
        {
            get => string.IsNullOrEmpty(LocationsJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(LocationsJson);
            set => LocationsJson = JsonSerializer.Serialize(value);
        }
    }
}
