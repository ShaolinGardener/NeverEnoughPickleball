using Microsoft.AspNetCore.Mvc;
using NEP.Models;

namespace NEP.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Simulating database save operation
                // In real application, you would save the model data to the database here

                // Redirect to login page after successful registration
                return RedirectToAction("Login", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


    }
}
