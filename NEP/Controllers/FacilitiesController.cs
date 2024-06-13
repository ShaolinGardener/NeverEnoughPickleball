using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEP.Data;
using NEP.Models;

namespace NEP.Controllers
{
    public class FacilitiesController : Controller
    {
        private readonly NEPContext _context;

        public FacilitiesController(NEPContext context)
        {
            _context = context;
        }


        // GET: Facilities
        public async Task<IActionResult> Index()
        {
            //var nEPContext = _context.Facilities.Include(f => f.Address);
            //return View(await nEPContext.ToListAsync());

            ViewBag.APIKey = ProximitySearch.APIKey;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(double radius, double? latitude, double? longitude, string? address)
        {
            double lat = 0.00;
            double lon = 0.00;
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
                lat = latitude.Value;
                lon = longitude.Value;
            }
            ProximitySearch ps = new ProximitySearch(_context);
            var facilities = ps.GetFacilitiesWithinRadiusWithDistance(lat, lon, radius);
            foreach (var facility in facilities)
            {
                facility.Courts = _context.Courts.Where(c => c.FacilityId == facility.Id).Include(c => c.CourtColors).ToList();
            }

            facilities = facilities.OrderBy(f => f.DistanceInMiles).ToList();
            if (facilities != null)
            {
                foreach (var facility in facilities)
                {
                    facility.Address = _context.Addresses.FirstOrDefault(a => a.Id == facility.AddressId);
                    var dim = _context.GetDistanceInMiles(facility.Id, lat, lon);
                    if (dim != null)
                        facility.DistanceInMiles = dim.Distance;
                }
            }
            CourtColors cc = new CourtColors();
            cc.CourtColor = "#00ff00";
            cc.OBColor = "#cccccc";
            cc.KitchenColor = "orange";
            cc.LineColor = "white";
            ViewBag.CourtColors = cc;
            ViewBag.Address = address;
            ViewBag.Radius = radius;
            ViewBag.APIKey = ProximitySearch.APIKey;

            return View(facilities);
        }

        public IActionResult Images(int id)
        {
            var facility = _context.Facilities.Find(id);
            ViewBag.FacilityImage = _context.Images.Find(facility.FacilityCourtIconImage);
            return View(facility);
        }
        public IActionResult Test()
        {
            //var nEPContext = _context.Facilities.Include(f => f.Address);
            //return View(await nEPContext.ToListAsync());

            //ViewBag.APIKey = ProximitySearch.APIKey;
            CourtColors cc = new CourtColors();
            cc.CourtColor = "#000022";
            cc.OBColor = "blue";
            cc.KitchenColor = "orange";
            cc.LineColor = "white";
            ViewBag.CourtColors = cc;
            return View();
        }



        // GET: Facilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facilities == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities
                .Include(f => f.Address)
                .Include(f => f.Courts)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }

            foreach (var court in facility.Courts)
            {
                court.CourtColors = _context.CourtColors.Where(c => c.CourtId == court.Id).FirstOrDefault();
                court.HoursOfPlay = _context.HoursOfPlay.Where(c => c.CourtId == court.Id).ToList();
            }

            return View(facility);
        }

        // GET: Facilities/Create
        public IActionResult Create()
        {
            //ViewBag.States = _context.States.ToList();
            ViewData["StateId"] = new SelectList(_context.States.OrderBy(s => s.Name), "Id", "Name");
            return View();
        }

        // POST: Facilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Phone,Url,ContactName,ContactEmail," +
            "IsPublic,NEPPartner,NumberOfCourts,IsFree,Fee,Memberships,MembershipFee,MembershipDiscountFee,Reservations," +
            "DropIns,NEPMembershipDiscount,hasTournaments,hasLeaguePlay,hasPartyBooking,hasSpecialEvents,hasCorporateRetreats," +
            "RestRooms,WaterFountain,Showers,LockerRooms,CarCharge,Playground,Picnic,Parking,Lights,Dedicated," +
            "Snacks,Beverages,BeverageOther,HasProShop")] Facility facility,
            string Address1, string Address2, string City, int StateId, string ZipCode)
        {
            Address address = new Address(_context) { Address1 = Address1, Address2 = Address2, City = City, StateId = StateId, ZipCode = ZipCode };

            var gl = ProximitySearch.GetLocationFromAddressAsync(address.Address1 + ", " + address.City + ", " + address.State + ", " + address.ZipCode);
            if (gl != null)
            {
                address.Latitude = gl.Latitude;
                address.Longitude = gl.Longitude;
                address.County = await ProximitySearch.GetCountyFromCoordinates(gl.Latitude, gl.Longitude);
            }

            _context.Add(address);
            facility.Address = address;
            //if (ModelState.IsValid)
            //{                
            _context.Add(facility);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details),new { id = facility.Id });
            //}
            //facility.Address.Address1 = Address1;
            //facility.Address.Address2 = Address2;
            //facility.Address.City = City;
            //facility.Address.ZipCode = ZipCode;
            //ViewBag.States = _context.States.ToList();
            ////ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Address1", facility.AddressId);
            //return View(facility);
        }

        // GET: Facilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facilities == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.States.OrderBy(s => s.Name), "Id", "Name");
            return View(facility);
        }

        // POST: Facilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,AddressId,Phone,Url,ContactName,ContactEmail" +
            "IsPublic,NEPPartner,NumberOfCourts,IsFree,Fee,Memberships,MembershipFee,MembershipDiscountFee,Reservations," +
            "DropIns,NEPMembershipDiscount,hasTournaments,hasLeaguePlay,hasPartyBooking,hasSpecialEvents,hasCorporateRetreats," +
            "RestRooms,WaterFountain,Showers,LockerRooms,CarCharge,Playground,Picnic,Parking,Lights,Dedicated," +
            "Snacks,Beverages,BeverageOther,HasProShop")] Facility facility,
            string Address1, string Address2, string City, int StateId, string ZipCode)
        {
            if (id != facility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityExists(facility.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.States.OrderBy(s => s.Name), "Id", "Name");
            return View(facility);
        }

        // GET: Facilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facilities == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities
                .Include(f => f.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // POST: Facilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facilities == null)
            {
                return Problem("Entity set 'NEPContext.Facilities'  is null.");
            }
            var facility = await _context.Facilities.FindAsync(id);
            if (facility != null)
            {
                _context.Facilities.Remove(facility);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(int id)
        {
            return (_context.Facilities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
