using Microsoft.AspNetCore.Mvc;
using NEP.Data;
using NEP.Models;

namespace NEP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly NEPContext _context;

        public ImagesController(NEPContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Images>>> GetImages()
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            return await _context.Images.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Images>> GetImages(int id)
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            var images = await _context.Images.FindAsync(id);

            if (images == null)
            {
                return NotFound();
            }

            return images;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImages(int id, Images images)
        {
            if (id != images.Id)
            {
                return BadRequest();
            }

            _context.Entry(images).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostImages([FromForm] IFormFile file, [FromForm] int facilityId, [FromForm] string imageName, [FromForm] string description, [FromForm] int width, [FromForm] int height)
        {
            //Facility f = new Facility();

            var facility = _context.Facilities.Find(facilityId);

            if (file == null || file.Length <= 0)
            {
                return BadRequest("Invalid file");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var imageData = memoryStream.ToArray();
                var image = new Images()
                {
                    ImageData = imageData,
                    Description = description,
                    Width = width,
                    Height = height,
                    Name = imageName
                };
                _context.Images.Add(image);
                await _context.SaveChangesAsync();
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
                    await _context.SaveChangesAsync();
                }

                return Ok("Image uploaded successfully");
            }

        }

        //// POST: api/Images
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Images>> PostImages(Images images) 
        //{

        //    if (_context.Images == null)
        //    {
        //        return Problem("Entity set 'NEPContext.Images'  is null.");
        //    }
        //    _context.Images.Add(images);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetImages", new { id = images.Id }, images);
        //}

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImages(int id)
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            var images = await _context.Images.FindAsync(id);
            if (images == null)
            {
                return NotFound();
            }

            _context.Images.Remove(images);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagesExists(int id)
        {
            return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
