using Microsoft.AspNetCore.Mvc;
using NEP.Models;
using NEP.Data;

namespace YourProject.Controllers
{
    public class MemberController : Controller
    {
        private readonly NEPContext _context;

        public MemberController(NEPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult BecomeMember()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BecomeMember(Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(member);
        }
    }
}
