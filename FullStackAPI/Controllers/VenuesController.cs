using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public VenuesController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/Venues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueModel>>> Getvenues()
        {
            return await _context.venues.ToListAsync();
        }

        // GET: api/Venues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenueModel>> GetVenueModel(int id)
        {
            var venueModel = await _context.venues.FindAsync(id);

            if (venueModel == null)
            {
                return NotFound();
            }

            return venueModel;
        }

        // PUT: api/Venues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenueModel(int id, VenueModel venueModel)
        {
            if (id != venueModel.VenueId)
            {
                return BadRequest();
            }

            _context.Entry(venueModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueModelExists(id))
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

        // POST: api/Venues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenueModel>> PostVenueModel(VenueModel venueModel)
        {
            _context.venues.Add(venueModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenueModel", new { id = venueModel.VenueId }, venueModel);
        }

        // DELETE: api/Venues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenueModel(int id)
        {
            var venueModel = await _context.venues.FindAsync(id);
            if (venueModel == null)
            {
                return NotFound();
            }

            _context.venues.Remove(venueModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenueModelExists(int id)
        {
            return _context.venues.Any(e => e.VenueId == id);
        }

    }
}
