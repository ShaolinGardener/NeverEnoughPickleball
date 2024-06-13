using Microsoft.AspNetCore.Mvc;
using NEP.Models;
using System.Diagnostics;

namespace NEP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TestLayout()
        {
            return View();
        }

        public IActionResult FromUrsaDev()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult IndexFromTemplate()
        {
            return View();
        }
    }
}