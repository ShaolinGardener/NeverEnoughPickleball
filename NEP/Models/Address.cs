using Microsoft.Extensions.Diagnostics.HealthChecks;
using NEP.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace NEP.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        [Required]
        public string Address1 { get; set; } = string.Empty;
        public string? Address2  { get; set; }
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }
        [Required]
        public string ZipCode { get; set; } = string.Empty;
        [Required]
        public string County { get; set; } = string.Empty;
        public State? State { get; set; }
        private readonly NEPContext _context;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Facility> Facilities { get; set; }
        public Address(NEPContext nepContext)
        {
            _context = nepContext;
            State = nepContext.States.Where(a => a.Id == StateId).FirstOrDefault();
            State ??= nepContext.States.Where(s => s.Name == "Florida").Single();
        }


        //public async void SetLatLongFromAddress(string address)
        //{
        //    string apiKey = "YOUR_API_KEY"; // Replace with your Google Maps API key
        //    //string address = "1600 Amphitheatre Parkway, Mountain View, CA";

        //    GoogleLocation location = await GetLocationFromAddressAsync(address, apiKey);

        //    if (location != null)
        //    {
        //        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error occurred while calling the Google Maps API.");
        //    }
        //}
    }
}
