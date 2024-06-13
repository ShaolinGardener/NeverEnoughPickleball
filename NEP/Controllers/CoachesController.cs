using Microsoft.AspNetCore.Mvc;

namespace NEP.Controllers
{
    public class CoachesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
