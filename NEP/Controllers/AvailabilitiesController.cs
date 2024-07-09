using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Models;

public class AvailabilitiesController : Controller
{
    private readonly NEPContext _context;

    public AvailabilitiesController(NEPContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create(int coachId)
    {
        ViewBag.CoachId = coachId;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FacilityName,FacilityContactEmail,BusinessHours,CoachId")] Availability availability)
    {
        if (ModelState.IsValid)
        {
            _context.Add(availability);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Coaches", new { id = availability.CoachId });
        }
        return View(availability);
    }
}
