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
    public class DiningFacilitiesController : Controller
    {
        private readonly NEPContext _context;

        public DiningFacilitiesController(NEPContext context)
        {
            _context = context;
        }

        // GET: DiningFacilities
        public async Task<IActionResult> Index(int facilityId)
        {
            var dining = _context.DiningFacilities.Where(d=>d.FacilityId == facilityId).Include(f=>f.Facility);
            return View(await dining.ToListAsync());
        }

        // GET: DiningFacilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DiningFacilities == null)
            {
                return NotFound();
            }

            var diningFacility = await _context.DiningFacilities
                .Include(d => d.Facility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diningFacility == null)
            {
                return NotFound();
            }

            return View(diningFacility);
        }

        // GET: DiningFacilities/Create
        public IActionResult Create()
        {
            ViewData["FacilityId"] = new SelectList(_context.Facilities, "Id", "Id");
            return View();
        }

        // POST: DiningFacilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,DiningFacilityType,DineIn,Delivery,BeerAndWine,FullLiquor,Reservations,Phone,URL,FacilityId,Menu,Image1,Image2,Image3")] DiningFacility diningFacility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diningFacility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacilityId"] = new SelectList(_context.Facilities, "Id", "Id", diningFacility.FacilityId);
            return View(diningFacility);
        }

        // GET: DiningFacilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DiningFacilities == null)
            {
                return NotFound();
            }

            var diningFacility = await _context.DiningFacilities.FindAsync(id);
            if (diningFacility == null)
            {
                return NotFound();
            }
            ViewData["FacilityId"] = new SelectList(_context.Facilities, "Id", "Id", diningFacility.FacilityId);
            return View(diningFacility);
        }

        // POST: DiningFacilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,DiningFacilityType,DineIn,Delivery,BeerAndWine,FullLiquor,Reservations,Phone,URL,FacilityId,Menu,Image1,Image2,Image3")] DiningFacility diningFacility)
        {
            if (id != diningFacility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diningFacility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiningFacilityExists(diningFacility.Id))
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
            ViewData["FacilityId"] = new SelectList(_context.Facilities, "Id", "Id", diningFacility.FacilityId);
            return View(diningFacility);
        }

        // GET: DiningFacilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DiningFacilities == null)
            {
                return NotFound();
            }

            var diningFacility = await _context.DiningFacilities
                .Include(d => d.Facility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diningFacility == null)
            {
                return NotFound();
            }

            return View(diningFacility);
        }

        // POST: DiningFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DiningFacilities == null)
            {
                return Problem("Entity set 'NEPContext.DiningFacilities'  is null.");
            }
            var diningFacility = await _context.DiningFacilities.FindAsync(id);
            if (diningFacility != null)
            {
                _context.DiningFacilities.Remove(diningFacility);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiningFacilityExists(int id)
        {
          return (_context.DiningFacilities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
