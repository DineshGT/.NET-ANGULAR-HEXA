using Event.DAL.Entities;
using Event.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repo;

        public EventController(IEventRepository repo)
            => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repo.GetAllEventsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ev = await _repo.GetEventByIdAsync(id);
            return ev is null ? NotFound() : Ok(ev);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(EventDetails ev)
        {
            await _repo.AddEventAsync(ev);
            return CreatedAtAction(nameof(Get), new { id = ev.EventId }, ev);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventDetails ev)
        {
            if (id != ev.EventId) return BadRequest();
            await _repo.UpdateEventAsync(ev);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteEventAsync(id);
            return NoContent();
        }
    }

}
