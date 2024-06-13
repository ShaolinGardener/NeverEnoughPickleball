using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Models;

namespace NEP.Controllers
{
    public class TestsController : Controller
    {
        private readonly NEPContext _context;
        public TestsController(NEPContext nepContext)
        {
            _context = nepContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddressLocation() {
            return View();
        }
        public IActionResult Facilities()
        {
            ViewBag.APIKey = ProximitySearch.APIKey;
            return View();
        }

        public IActionResult CourtTester()
        {
            CourtColors cc = new CourtColors() { OBColor = "#003300", CourtColor = "#009900", KitchenColor = "#ff9900", LineColor = "#ffffff" };
            ViewBag.ShowColorPicker = true;
            return View(cc);
        }

        [HttpPost]
        public IActionResult AddressLocation(string address)
        {
            ViewBag.Address = address;
            var gl = ProximitySearch.GetLocationFromAddressAsync(address);

            return View(gl);
        }

        /// <summary>
        /// Address will override lat/long if present
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Facilities(double radius,double? latitude, double? longitude, string? address) {
            double lat=0.00;
            double lon=0.00;
            if (address != null)
            {
                var gl = ProximitySearch.GetLocationFromAddressAsync(address);
                lat = gl.Latitude;
                lon = gl.Longitude;
                ViewBag.Latitude = lat;
                ViewBag.Longitude = lon;
            }
            else
            {
                lat=latitude.Value;
                lon=longitude.Value;
            }
            ProximitySearch ps = new ProximitySearch(_context);
            var facilities = ps.GetFacilitiesWithinRadiusWithDistance(lat, lon, radius);
            if (facilities != null)
            {
                foreach(var facility in facilities)
                {
                    facility.Address = _context.Addresses.FirstOrDefault(a=>a.Id==facility.AddressId);
                }
            }
            ViewBag.Address = address;
            ViewBag.Radius = radius;
            ViewBag.APIKey = ProximitySearch.APIKey;

            return View(facilities);
         }
    }
}
