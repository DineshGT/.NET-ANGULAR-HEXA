using Event.DAL.Entities;
using Event.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerRepository _repo;

        public SpeakerController(ISpeakerRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllSpeakersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            await _repo.GetSpeakerByIdAsync(id) is SpeakersDetails s ? Ok(s) : NotFound();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(SpeakersDetails s)
        {
            await _repo.AddSpeakerAsync(s);
            return CreatedAtAction(nameof(Get), new { id = s.SpeakerId }, s);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SpeakersDetails s)
        {
            if (id != s.SpeakerId) return BadRequest();
            await _repo.UpdateSpeakerAsync(s);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteSpeakerAsync(id);
            return NoContent();
        }
    }

}
