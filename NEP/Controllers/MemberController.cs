using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoogleApi.Entities.Search.Video.Common;
using System.IO;

namespace NEP.Controllers
{
    public class MemberController : Controller
    {
        private readonly NEPContext _context;

        public MemberController(NEPContext context)
        {
            _context = context;
        }

        // GET: Member
        public async Task<IActionResult> Index()
        {
            return View(await _context.Members.ToListAsync());
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ScreenName,CompanyOrOrganization,DateOfBirth,Street,AptSuiteNumber," +
    "City,State,Zip,Phone,Email,PlayType,UnofficialRating,DuprRating,UtprRating,PaddleUsed,PersonalBio,VolunteerInterest," +
    "PlayedState,PlayedCity,PlayedParkFacility,AvailableFacilitiesName,AvailableFacilitiesContactEmail,HowDidYouHearAboutNEP," +
            "SuggestionsForNEP")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to the list of members after successful creation
            }
            return View(member);
        }



        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Member/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ScreenName,CompanyOrOrganization,DateOfBirth,Street,AptSuiteNumber," +
    "City,State,Zip,Phone,Email,PlayType,UnofficialRating,DuprRating,UtprRating,PaddleUsed,PersonalBio,VolunteerInterest," +
    "PlayedState,PlayedCity,PlayedParkFacility,AvailableFacilitiesName," +
            "AvailableFacilitiesContactEmail,HowDidYouHearAboutNEP," +
            "SuggestionsForNEP")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }


        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
