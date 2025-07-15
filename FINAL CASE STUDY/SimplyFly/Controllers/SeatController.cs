using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DTOs.Models.Seat;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [AllowAnonymous] 
        [HttpGet("route/{routeId}")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeatsByRoute(int routeId)
        {
            return Ok(await _seatService.GetSeatsByRouteAsync(routeId));
        }



        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> CreateSeat([FromBody] SeatCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var seat = new Seat
            {
                SeatNumber = dto.SeatNumber,
                IsBooked = dto.IsBooked,
                RouteId = dto.RouteId
            };

            await _seatService.CreateSeatAsync(seat);
            return Ok("Seat created successfully.");
        }

        // to create seats in bulk
        [Authorize(Roles = "Owner")]
        [HttpPost("bulk")]
        public async Task<IActionResult> BulkCreateSeats(int routeId, int totalSeats)
        {
            await _seatService.BulkCreateSeatsAsync(routeId, totalSeats);
            return Ok($"{totalSeats} seats created successfully for route ID {routeId}.");
        }



        [Authorize(Roles = "User")]
        [HttpPut("book/{seatId}")]
        public async Task<ActionResult> BookSeat(int seatId)
        {
            await _seatService.MarkSeatAsBookedAsync(seatId);
            return NoContent();
        }

        [Authorize(Roles = "Owner")]
        [HttpPut("reset/{seatId}")]
        public async Task<ActionResult> ResetSeat(int seatId)
        {
            await _seatService.ResetSeatAsync(seatId);
            return NoContent();
        }
    }
}
