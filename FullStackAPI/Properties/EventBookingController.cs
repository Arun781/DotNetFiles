using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventBookingController : ControllerBase
    {

        private readonly FullStackDbContext _context;

        public EventBookingController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/EventBooking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventModel>>> Getevents()
        {
            return await _context.events.ToListAsync();
        }

        // GET: api/EventBooking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel>> GetEventModel(int id)
        {
            var eventModel = await _context.events.FindAsync(id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return eventModel;
        }

        // PUT: api/EventBooking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventModel(int id, EventModel eventModel)
        {
            if (id != eventModel.EventID)
            {
                return BadRequest();
            }

            _context.Entry(eventModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventModelExists(id))
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

        // POST: api/EventBooking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventModel>> PostEventModel(EventModel eventModel)
        {
            _context.events.Add(eventModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventModel", new { id = eventModel.EventID }, eventModel);
        }

        // DELETE: api/EventBooking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventModel(int id)
        {
            var eventModel = await _context.events.FindAsync(id);
            if (eventModel == null)
            {
                return NotFound();
            }

            _context.events.Remove(eventModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventModelExists(int id)
        {
            return _context.events.Any(e => e.EventID == id);
        }

    }
}
