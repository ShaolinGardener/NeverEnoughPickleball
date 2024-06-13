using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEP.Data;
using NEP.Migrations;
using NEP.Models;
using NuGet.Protocol;

namespace NEP.Controllers
{
    public class CourtsController : Controller
    {
        private readonly NEPContext _context;

        public CourtsController(NEPContext context)
        {
            _context = context;
        }

        // GET: Courts
        public IActionResult Index(int id)
        {
            var courts = _context.Courts.Where(c => c.FacilityId == id).Include(f => f.Facility).Include(c => c.CourtColors).ToList();
            ViewBag.FacilityId = id;
            return View(courts);
        }

        // GET: Courts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courts == null)
            {
                return NotFound();
            }

            var court = await _context.Courts
                .Include(c => c.Facility)
                .Include(c => c.CourtColors)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        // GET: Courts/Create
        public IActionResult Create(int facilityId)
        {
            CourtColors cc = new CourtColors() { OBColor = "#003300", CourtColor = "#009900", KitchenColor = "#ff9900", LineColor = "#ffffff" };
            var facility = _context.Facilities.FirstOrDefault(c => c.Id == facilityId);
            //ViewBag.PreferredPlayerMinimumRanking = rankings;// Utility.GetPlayerRankingSelectList();
            ViewBag.ShowColorPicker = true;
            ViewBag.Facility = facility;
            return View();
        }

        // POST: Courts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string obcolor, string linecolor, string courtcolor, string kitchencolor, [Bind("Id,Name,FacilityId,IsIndoor,Surface,Nets,Lines,PreferredPlayerMinimumRanking")] Court court)
        {
            _context.Courts.Add(court);
            await _context.SaveChangesAsync();
            CourtColors cc = new CourtColors() { OBColor = obcolor, LineColor = linecolor, CourtColor = courtcolor, KitchenColor = kitchencolor };
            _context.CourtColors.Add(cc);
            court.CourtColors = cc;
            _context.SaveChanges();
            //await _context.SaveChangesAsync();
            //if (ModelState.IsValid)
            //{


            //return RedirectToAction(nameof(HoursOfPlay), new { id = court.Id });
            ////}
            //var rankings = Utility.GetPlayerRankingSelectList();

            //ViewBag.PreferredPlayerMinimumRanking = rankings;
            return RedirectToAction("Create", new { id = court.FacilityId });

            //return View(court);
        }

        [HttpGet]
        public IActionResult CreateHoursOfPlay(int courtId)
        {
            var court = _context.Courts.FirstOrDefault(c => c.Id == courtId);
            court.HoursOfPlay = _context.HoursOfPlay.Where(h => h.CourtId == courtId).OrderBy(h => h.WeekDay).ThenBy(h => h.Hours).ToList();

            ViewBag.Court = court;
            List<object> weekDays = new List<object>();
            for (var i = 0; i < 7; i++)
            {
                var weekDay = new { Id = i, DayOfWeek = (DayOfWeek)i };
                weekDays.Add(weekDay);
            }

            //var weekdays = Utility.GetWeekDaysSelectList();
            SelectList wd = new SelectList(weekDays, "Id", "DayOfWeek");
            ViewBag.HoursOfPlay = court.HoursOfPlay;
            ViewData["WeekDays"] = wd;
            return View();
        }

        [HttpPost]
        public IActionResult CreateHoursOfPlay(int courtId, int weekday, string hours, string usageType, double fee)
        {
            var court = _context.Courts.FirstOrDefault(c => c.Id == courtId);
            court.HoursOfPlay = _context.HoursOfPlay.Where(h => h.CourtId == courtId).OrderBy(h => h.WeekDay).ThenBy(h => h.Hours).ToList();
            ViewBag.Court = court;
            ViewBag.HoursOfPlay = court.HoursOfPlay;

            List<object> weekDays = new List<object>();
            for (var i = 0; i < 7; i++)
            {
                var weekDay = new { Id = i, DayOfWeek = (DayOfWeek)i };
                weekDays.Add(weekDay);
            }

            //var weekdays = Utility.GetWeekDaysSelectList();
            SelectList wd = new SelectList(weekDays, "Id", "DayOfWeek", weekday);
            ViewData["WeekDays"] = wd;
            try
            {
                var isfee = fee >= 0;
                //if (fee != null && !string.IsNullOrEmpty(fee))
                //{
                //    var feeDbl = double.Parse(fee);
                //}
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Fee", "Please enter a dollar amount for fee.");
                if (!ModelState.IsValid)
                {
                    // Handle the case where validation failed
                    // For example, return the view with the invalid model

                    return View();
                }
            }

            var hoursOfPlay = new HoursOfPlay()
            {
                CourtId = courtId,
                WeekDay = weekday,
                Hours = hours,
                Fee = fee,
                UsageType = usageType,
            };
            _context.HoursOfPlay.Add(hoursOfPlay);

            if (court != null)
            {
                court.HoursOfPlay.Add(hoursOfPlay);
                _context.SaveChanges();
            }
            ViewBag.Court = court;
            return RedirectToAction(nameof(HoursOfPlay), new
            {
                courtId = courtId
            });
        }

        // GET: Courts/Edit/5
        public IActionResult Edit(int id)
        {
            var court = _context.Courts.Where(c => c.Id == id).Include(c => c.Facility).Include(c=>c.CourtColors).FirstOrDefault();
            if (court == null)
            {
                return NotFound();
            }
            ViewBag.ShowColorPicker = true;

            return View(court);
        }

        // POST: Courts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string obcolor, string linecolor, string courtcolor, string kitchencolor, [Bind("Id,Name,IsIndoor,Surface,Nets,Lines,PreferredPlayerMinimumRanking")] Court court)
        {
            if (id != court.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(court);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourtExists(court.Id))
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
            ViewBag.ShowColorPicker = true;
            var rankings = Utility.GetPlayerRankingSelectList();
            ViewData["PreferredPlayerMinimumRanking"] = rankings;
            return View(court);
        }

        // GET: Courts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courts == null)
            {
                return NotFound();
            }

            var court = await _context.Courts
                .Include(c => c.Facility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        // POST: Courts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courts == null)
            {
                return Problem("Entity set 'NEPContext.Court'  is null.");
            }
            var court = await _context.Courts.FindAsync(id);
            if (court != null)
            {
                _context.Courts.Remove(court);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourtExists(int id)
        {
            return (_context.Courts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
