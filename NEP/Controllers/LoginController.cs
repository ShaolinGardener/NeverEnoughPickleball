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
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Dummy login validation for demonstration purposes
                if (model.Email == "test@example.com" && model.Password == "password" && model.MemberType == "Member")
                {
                    // Redirect to home page on successful login
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }
    }
}
