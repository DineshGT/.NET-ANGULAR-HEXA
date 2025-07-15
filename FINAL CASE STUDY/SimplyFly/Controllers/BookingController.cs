using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DTOs.Models.Booking;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [Authorize(Roles = "User,Admin, Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBookings()
        {
            return Ok(await _bookingService.GetAllBookingsAsync());
        }

        [Authorize(Roles = "User, Admin, Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);

            if (booking == null)
                return NotFound();

            
          

            return Ok(booking);
        }

        [Authorize(Roles = "User,Admin, Owner")]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingsByUser(int userId)
        {
            var bookings = await _bookingService.GetBookingsByUserAsync(userId);

            var userRole = User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
            var userIdClaim = User.FindFirst("id")?.Value;

            if (userRole == "User" && userId.ToString() != userIdClaim)
                return Forbid();

            return Ok(bookings);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDTO dto)
        {
            var booking = new Booking
            {
                UserId = dto.UserId,
                RouteId = dto.RouteId,
                BookingDate = dto.BookingDate,
                NumberOfSeats = dto.NumberOfSeats,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status
            };

            await _bookingService.CreateBookingAsync(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }

        [Authorize(Roles = "User")]
        [HttpPut("cancel/{id}")]
        public async Task<ActionResult> CancelBooking(int id)
        {
            await _bookingService.CancelBookingAsync(id);
            return NoContent();
        }

        [Authorize(Roles = "Owner")]
        [HttpGet("owner/{ownerId}")]
        public async Task<IActionResult> GetBookingsByOwner(int ownerId)
        {
            var bookings = await _bookingService.GetBookingsByOwnerAsync(ownerId);
            return Ok(bookings);
        }

    }
}
