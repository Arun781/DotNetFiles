using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        FullStackDbContext _firstContext;
        public AuthController(FullStackDbContext Context)
        {
            _firstContext = Context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> isUserPresent([FromRoute] string id)
        {
            var user = await _firstContext.logins.FindAsync(id);
            if (user == null)
                return NotFound(false);
            else return Ok(true);

        }
        [HttpGet("{ids}")]
        public async Task<IActionResult> isAdminPresent([FromRoute] string ids)
        {
            var user = await _firstContext.logins.FindAsync(ids);
            if (user == null)
                return NotFound(false);
            else return Ok(true);

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SaveUser([FromBody] UserModel model)
        {
            await _firstContext.users.AddAsync(model);
            await _firstContext.SaveChangesAsync();
            return Ok(model);
        }
        [HttpPost("SaveAdmin")]
        public async Task<IActionResult> SaveAdmin([FromBody] AdminModel models)
        {
            await _firstContext.admins.AddAsync(models);
            await _firstContext.SaveChangesAsync();
            return Ok(models);
        }

    }
}
