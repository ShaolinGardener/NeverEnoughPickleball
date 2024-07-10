using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEP.Data;
using NEP.Models;

namespace NEP.Controllers
{
    public class CoachesController : Controller
    {
        private readonly NEPContext _context;

        public CoachesController(NEPContext context)
        {
            _context = context;
        }

        // GET: Coaches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coaches.ToListAsync());
        }

        // GET: Coaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // GET: Coaches/DetailsSocialMedia/5
        public async Task<IActionResult> DetailsSocialMedia(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coachSocialMedia = await _context.CoachSocialMedias.FirstOrDefaultAsync(m => m.Id == id);
            if (coachSocialMedia == null)
            {
                return NotFound();
            }

            return View(coachSocialMedia);
        }

        // GET: Coaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Email,PhoneNumber,Specialization")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        // GET: Coaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Email,PhoneNumber,Specialization")] Coach coach)
        {
            if (id != coach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.Id))
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
            return View(coach);
        }

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            if (coach != null)
            {
                _context.Coaches.Remove(coach);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CoachExists(int id)
        {
            return _context.Coaches.Any(e => e.Id == id);
        }

        // GET: Coaches/AddSocialMedia/5
        public async Task<IActionResult> AddSocialMedia(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }

            var coachSocialMedia = new CoachSocialMedia { CoachId = coach.Id };
            return View(coachSocialMedia);
        }
        // GET: Coaches/ViewSocialMedia/5
        public async Task<IActionResult> ViewSocialMedia(int? coachId)
        {
            if (coachId == null)
            {
                return NotFound();
            }

            var coachSocialMedia = await _context.CoachSocialMedias
                                        .FirstOrDefaultAsync(m => m.CoachId == coachId);

            if (coachSocialMedia == null)
            {
                return NotFound();
            }

            return View(coachSocialMedia);
        }

        // POST: Coaches/AddSocialMedia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSocialMedia([Bind("CoachId,Facebook,Instagram,YouTube,Twitter,LinkedIn,WhatsApp,TikTok,Snapchat")] CoachSocialMedia coachSocialMedia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coachSocialMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ViewSocialMedia), new { coachId = coachSocialMedia.CoachId });
            }
            return View(coachSocialMedia);
        }

        public async Task<IActionResult> EditSocialMedia(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.CoachSocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            return View("AddSocialMedia", socialMedia); // Use AddSocialMedia view for editing
        }

        // POST: SocialMedia/SaveSocialMedia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSocialMedia(int id, [Bind("Id,Facebook,Instagram,YouTube,Twitter,LinkedIn,WhatsApp,TikTok,Snapchat")] CoachSocialMedia coachSocialMedia)
        {
            if (id != coachSocialMedia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coachSocialMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachSocialMediaExists(coachSocialMedia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ViewSocialMedia", new { id = coachSocialMedia.Id });
            }
            return View("AddSocialMedia", coachSocialMedia); // Return to edit view if validation fails
        }
        private bool CoachSocialMediaExists(int id)
        {
            return _context.CoachSocialMedias.Any(e => e.Id == id);
        }

        // GET: Coaches/AddAvailability/5
        public IActionResult AddAvailability(int coachId)
        {
            return RedirectToAction("Create", "Availabilities", new { coachId = coachId });
        }

    }
}
