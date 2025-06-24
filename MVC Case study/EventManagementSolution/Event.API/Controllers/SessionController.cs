using Event.DAL.Entities;
using Event.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _repo;

        public SessionController(ISessionRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllSessionsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            await _repo.GetSessionByIdAsync(id) is SessionInfo s ? Ok(s) : NotFound();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(SessionInfo s)
        {
            await _repo.AddSessionAsync(s);
            return CreatedAtAction(nameof(Get), new { id = s.SessionId }, s);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SessionInfo s)
        {
            if (id != s.SessionId) return BadRequest();
            await _repo.UpdateSessionAsync(s);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteSessionAsync(id);
            return NoContent();
        }
    }

}
