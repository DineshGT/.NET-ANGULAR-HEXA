using Event.DAL.Entities;
using Event.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Event.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantEventController : ControllerBase
    {
        private readonly IParticipantEventRepository _repo;

        public ParticipantEventController(IParticipantEventRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repo.GetAllParticipantEventsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            await _repo.GetByIdAsync(id) is ParticipantEventDetails p
                ? Ok(p)
                : NotFound();

        [Authorize(Roles = "Participant")]
        [HttpPost]
        public async Task<IActionResult> Create(ParticipantEventDetails p)
        {
            // Ensure participant email matches the logged-in user
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if (email != p.ParticipantEmailId)
                return Forbid("Cannot register event for another user.");

            await _repo.AddAsync(p);
            return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
        }

        [Authorize(Roles = "Participant")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ParticipantEventDetails p)
        {
            if (id != p.Id) return BadRequest();

            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if (email != p.ParticipantEmailId)
                return Forbid();

            await _repo.UpdateAsync(p);
            return NoContent();
        }

        [Authorize(Roles = "Participant")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if (existing == null || existing.ParticipantEmailId != email)
                return Forbid();

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }

}
