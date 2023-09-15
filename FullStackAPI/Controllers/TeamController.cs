using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public TeamController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamModel>>> Getteams()
        {
            return await _context.teams.ToListAsync();
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamModel>> GetTeamModel(int id)
        {
            var teamModel = await _context.teams.FindAsync(id);

            if (teamModel == null)
            {
                return NotFound();
            }

            return teamModel;
        }

        // PUT: api/Team/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamModel(int id, TeamModel teamModel)
        {
            if (id != teamModel.TeamID)
            {
                return BadRequest();
            }

            _context.Entry(teamModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamModelExists(id))
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

        // POST: api/Team
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamModel>> PostTeamModel(TeamModel teamModel)
        {
            _context.teams.Add(teamModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamModel", new { id = teamModel.TeamID }, teamModel);
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamModel(int id)
        {
            var teamModel = await _context.teams.FindAsync(id);
            if (teamModel == null)
            {
                return NotFound();
            }

            _context.teams.Remove(teamModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamModelExists(int id)
        {
            return _context.teams.Any(e => e.TeamID == id);
        }

    }
}
