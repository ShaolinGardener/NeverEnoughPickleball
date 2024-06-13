using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Models;

namespace NEP.Controllers
{
    public class ManagementController : Controller
    {
        private readonly NEPContext _context;
        public ManagementController(NEPContext nepContext)
        {
            _context = nepContext;
        }

        [HttpGet]
        public IActionResult Emails()
        {
            var model = _context.Emails.Where(e => !e.IsDeleted).ToList();
            return View(model);
        }

        [HttpPost]
        public void UpdateEmailMarkRead(Guid id)
        {
            var email = _context.Emails.Where(e => e.Id == id).SingleOrDefault();
            if (email != null)
            {
                email.IsNew = false;
                _context.Emails.Update(email);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult SendEmails()
        {
            return View();
        }

        [HttpPost]
        public void DeleteEmail(Guid id)
        {
            var email = _context.Emails.Where(e => e.Id == id).SingleOrDefault();
            if (email != null)
            {
                _context.Emails.Remove(email);
                _context.SaveChanges();
            }
        }
    }
}
