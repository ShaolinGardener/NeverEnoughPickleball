using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Models;

namespace NEP.Controllers
{
    public class RegisterController : Controller
    {
        private readonly NEPContext _context;

        public RegisterController(NEPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Check if a user with the same email already exists
                var existingUser = _context.Users.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "An account with this email already exists.");
                    return View("Index", model);
                }

                model.UserName = model.Email;

                // Create a new user object and save to the database
                model.Id = Guid.NewGuid(); // Generate a unique ID for the user
                model.DateCreated = DateTime.Now; // Set the date of creation
                model.IsActive = true; // Activate the user account by default

                _context.Users.Add(model); // Add the user to the context
                _context.SaveChanges(); // Save changes to the database

                // Redirect to the login page after successful registration
                return RedirectToAction("Index", "Login");
            }

            // If the model state is invalid, redisplay the form with validation messages
            return View("Index", model);
        }
    }
}
