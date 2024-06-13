using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NEP.Data;

namespace NEP.Controllers
{
    public class CorporateDocumentsController : Controller
    {
        private readonly NEPContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CorporateDocumentsController(NEPContext nepContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = nepContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index() {
            var policies = _context.Policies.ToList();
            ViewBag.Policies = policies;
            var financials = _context.Financials.ToList();
            ViewBag.Financials = financials;
            return View();
        }        
    }
}
