using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers
{
    [Authorize(Roles = "Participant")]
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        [HttpGet("courses")]
        public IActionResult GetCourses()
        {
            return Ok("Participant's course list");
        }
    }
}
