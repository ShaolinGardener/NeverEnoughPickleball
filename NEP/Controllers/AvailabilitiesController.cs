using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEP.Data;
using NEP.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NEP.Controllers
{
    public class AvailabilitiesController : Controller
    {
        private readonly NEPContext _context;

        public AvailabilitiesController(NEPContext context)
        {
            _context = context;
        }

        // GET: Availabilities/Create
        public IActionResult Create(int coachId)
        {
            ViewBag.CoachId = coachId;
            return View();
        }

        // POST: Availabilities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoachId,FacilityName,FacilityContactEmail,MondayHours,TuesdayHours,WednesdayHours,ThursdayHours,FridayHours,SaturdayHours,SundayHours,HolidayName,HolidayHours,ScheduledHolidays,AdditionalNotes")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(availability);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = availability.Id });
            }
            return View(availability);
        }

        // GET: Availabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availabilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // GET: Availabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availabilities.FindAsync(id);
            if (availability == null)
            {
                return NotFound();
            }
            return View(availability);
        }

        // POST: Availabilities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoachId,FacilityName,FacilityContactEmail,MondayHours,TuesdayHours,WednesdayHours,ThursdayHours,FridayHours,SaturdayHours,SundayHours,HolidayName,HolidayHours,ScheduledHolidays,AdditionalNotes")] Availability availability)
        {
            if (id != availability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailabilityExists(availability.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = availability.Id });
            }
            return View(availability);
        }

        // GET: Availabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availabilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // POST: Availabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availability = await _context.Availabilities.FindAsync(id);
            _context.Availabilities.Remove(availability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailabilityExists(int id)
        {
            return _context.Availabilities.Any(e => e.Id == id);
        }
    }
}
