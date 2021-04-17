using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenHabWebApp.Data;
using OpenHabWebApp.Domain;

namespace OpenHabApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Esp32camImageController : ControllerBase
    {
        private readonly DataContext _context;

        public Esp32camImageController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Esp32camImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Esp32camImage>>> GetEsp32camImages()
        {
            return await _context.Esp32camImages.ToListAsync();
        }

        // GET: api/Esp32camImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Esp32camImage>> GetEsp32camImage(int id)
        {
            var esp32camImage = await _context.Esp32camImages.FindAsync(id);

            if (esp32camImage == null)
            {
                return NotFound();
            }

            return esp32camImage;
        }

        // PUT: api/Esp32camImage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEsp32camImage(int id, Esp32camImage esp32camImage)
        {
            if (id != esp32camImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(esp32camImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Esp32camImageExists(id))
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

        // POST: api/Esp32camImage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Esp32camImage>> PostEsp32camImage(Esp32camImage esp32camImage)
        //{
        //    _context.Esp32camImages.Add(esp32camImage);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEsp32camImage", new { id = esp32camImage.Id }, esp32camImage);
        //}

        [HttpPost]
        public ActionResult PostEsp32camImage([FromForm] Esp32camImage esp32camImage)
        {
            try
            {
                _context.Esp32camImages.Add(esp32camImage);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        // DELETE: api/Esp32camImage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Esp32camImage>> DeleteEsp32camImage(int id)
        {
            var esp32camImage = await _context.Esp32camImages.FindAsync(id);
            if (esp32camImage == null)
            {
                return NotFound();
            }

            _context.Esp32camImages.Remove(esp32camImage);
            await _context.SaveChangesAsync();

            return esp32camImage;
        }

        private bool Esp32camImageExists(int id)
        {
            return _context.Esp32camImages.Any(e => e.Id == id);
        }
    }
}
