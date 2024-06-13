using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEP.Data;
using NEP.Migrations;
using NEP.Models;

namespace NEP.Controllers
{
    public class ImagesController : Controller
    {
        private readonly NEPContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImagesController(NEPContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            return _context.Images != null ?
                        View(await _context.Images.ToListAsync()) :
                        Problem("Entity set 'NEPContext.Images'  is null.");
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, [FromForm] int facilityId, [FromForm] string imageName, [FromForm] string description, [FromForm] int width, [FromForm] int height)
        {
            var facility = _context.Facilities.Find(facilityId);

            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    var fileData = memoryStream.ToArray();

                    var image = new Images()
                    {
                        ImageData = fileData,
                        Description = description,
                        Width = width,
                        Height = height,
                        Name = imageName
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    if (facility != null)
                    {
                        switch (imageName)
                        {
                            case "thumbnail":
                                facility.FacilityCourtIconImage = image.Id;
                                break;
                            case "image1":
                                facility.CourtImage1 = image.Id;
                                break;
                            case "image2":
                                facility.CourtImage2 = image.Id;
                                break;
                            case "image3":
                                facility.CourtImage3 = image.Id;
                                break;
                            case "image4":
                                facility.CourtImage4 = image.Id;
                                break;
                            case "image5":
                                facility.CourtImage5 = image.Id;
                                break;

                        }
                        _context.SaveChanges();
                    }

                    return RedirectToAction("Images", "Facilities",new {id=facilityId});
                }


            }
            return Content("Error uploading file.");

        }


        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (images == null)
            {
                return NotFound();
            }

            return View(images);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageData,Name,Width,Height,Description")] Images images)
        {
            if (ModelState.IsValid)
            {
                _context.Add(images);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(images);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images.FindAsync(id);
            if (images == null)
            {
                return NotFound();
            }
            return View(images);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageData,Name,Width,Height,Description")] Images images)
        {
            if (id != images.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(images);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagesExists(images.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(images);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (images == null)
            {
                return NotFound();
            }

            return View(images);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Images == null)
            {
                return Problem("Entity set 'NEPContext.Images'  is null.");
            }
            var images = await _context.Images.FindAsync(id);
            if (images != null)
            {
                _context.Images.Remove(images);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagesExists(int id)
        {
            return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
