using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NEP.Data;

namespace NEP.Controllers
{
    public class PolicyController : Controller
    {
        private readonly NEPContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PolicyController(NEPContext nepContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = nepContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index() {
            //return Content("<a href=\"/Policy/GetPolicy?policyName=CoachesAdmin.pdf\">Coaches Admin</a>");
            var model = _context.Policies.ToList();
            return View(model);
        }

        public IActionResult GetPolicy(string policyName)
        {
            var policy = _context.Policies.Where(p => p.Name == policyName).FirstOrDefault();
            if (policy == null)
            {
                return Content("No Policy Found");
            }
            // Assuming you have a PDF file stored on the server
            string filePath = policy.FilePath;

            string physicalPath = _webHostEnvironment.WebRootPath + filePath.Replace("/","\\"); 

            // Read the file content into a byte array
            byte[] fileBytes = System.IO.File.ReadAllBytes(physicalPath);

            // Set the content type to "application/pdf"
            string contentType = "application/pdf";

            // Optionally, specify the file name for the user to download
            string fileName = policy.Name.Contains(".pdf") ? policy.Name : policy.Name + ".pdf";

            // Return the file as a file download response
            return File(fileBytes, contentType, fileName);
        }

        public ContentResult GetPolicyDetails(string policyName)
        {
            var policy = _context.Policies.Where(p => p.Name == policyName).FirstOrDefault();
            if (policy == null)
            {
                return Content("No Policy Found");
            }

            string fileName = policy.Name;
            return Content("<a href=\"/Policy/GetPolicy?policyName=" + fileName + "\">" + fileName + "</a>");
        }
    }
}
