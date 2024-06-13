using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NEP.Data;

namespace NEP.Controllers
{
    public class FinancialController : Controller
    {
        private readonly NEPContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FinancialController(NEPContext nepContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = nepContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index() {
            //return Content("<a href=\"/Financial/GetFinancial?financialName=CoachesAdmin.pdf\">Coaches Admin</a>");
            var model = _context.Policies.ToList();
            return View(model);
        }

        public IActionResult GetFinancial(string financialName)
        {
            var financial = _context.Policies.Where(p => p.Name == financialName).FirstOrDefault();
            if (financial == null)
            {
                return Content("No Financial Found");
            }
            // Assuming you have a PDF file stored on the server
            string filePath = financial.FilePath;

            string physicalPath = _webHostEnvironment.WebRootPath + filePath.Replace("/","\\"); 

            // Read the file content into a byte array
            byte[] fileBytes = System.IO.File.ReadAllBytes(physicalPath);

            // Set the content type to "application/pdf"
            string contentType = "application/pdf";

            // Optionally, specify the file name for the user to download
            string fileName = financial.Name.Contains(".pdf") ? financial.Name : financial.Name + ".pdf";

            // Return the file as a file download response
            return File(fileBytes, contentType, fileName);
        }

        public ContentResult GetFinancialDetails(string financialName)
        {
            var financial = _context.Policies.Where(p => p.Name == financialName).FirstOrDefault();
            if (financial == null)
            {
                return Content("No Financial Found");
            }

            string fileName = financial.Name;
            return Content("<a href=\"/Financial/GetFinancial?financialName=" + fileName + "\">" + fileName + "</a>");
        }
    }
}
