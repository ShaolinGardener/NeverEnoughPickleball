using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Models;

namespace NEP.Controllers
{
    public class LoginController : Controller
    {
        private readonly NEPContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LoginController(NEPContext nepContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = nepContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("Email", "Email is required.");
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Password is required.");
            }

            if (ModelState.IsValid)
            {
                // Check if a user with the provided email and password exists
                var user = _context.Users
                    .FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && u.Password == password);

                if (user != null)
                {
                    // Redirect to the home page after successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Add an error if the user was not found
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // If we got this far, something failed; redisplay the form
            return View("Index");
        }
    }
}
