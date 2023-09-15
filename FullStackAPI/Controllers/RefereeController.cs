using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereeController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public RefereeController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/Referee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefereeModel>>> Getreferees()
        {
            return await _context.referees.ToListAsync();
        }

        // GET: api/Referee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RefereeModel>> GetRefereeModel(int id)
        {
            var refereeModel = await _context.referees.FindAsync(id);

            if (refereeModel == null)
            {
                return NotFound();
            }

            return refereeModel;
        }

        // PUT: api/Referee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefereeModel(int id, RefereeModel refereeModel)
        {
            if (id != refereeModel.RefereeID)
            {
                return BadRequest();
            }

            _context.Entry(refereeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefereeModelExists(id))
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

        // POST: api/Referee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RefereeModel>> PostRefereeModel(RefereeModel refereeModel)
        {
            _context.referees.Add(refereeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRefereeModel", new { id = refereeModel.RefereeID }, refereeModel);
        }

        // DELETE: api/Referee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefereeModel(int id)
        {
            var refereeModel = await _context.referees.FindAsync(id);
            if (refereeModel == null)
            {
                return NotFound();
            }

            _context.referees.Remove(refereeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RefereeModelExists(int id)
        {
            return _context.referees.Any(e => e.RefereeID == id);
        }

    }
}
