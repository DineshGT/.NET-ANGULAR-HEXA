using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DTOs.Models.Flight;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetAllFlights()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(flights);
        }

        //to search flight using inputs..

    //    [AllowAnonymous] // Or use [Authorize(Roles = "User")] if login is required
    //[HttpGet("search")]
    //public async Task<ActionResult<IEnumerable<Flight>>> SearchFlights(
    //[FromQuery] string origin,
    //[FromQuery] string destination,
    //[FromQuery] DateTime date)
    //{
    //    var flights = await _flightService.SearchFlightsAsync(origin, destination, date);

    //    return Ok(flights);
    //}

    [Authorize(Roles = "Owner,Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet("owner/{ownerId}")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlightsByOwner(int ownerId)
        {
            return Ok(await _flightService.GetFlightsByOwnerAsync(ownerId));
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] FlightCreateDTO dto)
        {
            var flight = new Flight
            {
                FlightName = dto.FlightName,
                FlightNumber = dto.FlightNumber,
                BaggageCheckIn = dto.BaggageCheckIn,
                BaggageCabin = dto.BaggageCabin,
                TotalSeats = dto.TotalSeats,
                OwnerId = dto.OwnerId,
                IsApproved = false
            };

            await _flightService.CreateFlightAsync(flight);
            return CreatedAtAction(nameof(GetFlight), new { id = flight.FlightId }, flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightUpdateDTO dto)
        {
            if (id != dto.FlightId)
                return BadRequest("Flight ID mismatch");

            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound("Flight not found.");

            flight.FlightName = dto.FlightName;
            flight.FlightNumber = dto.FlightNumber;
            flight.BaggageCheckIn = dto.BaggageCheckIn;
            flight.BaggageCabin = dto.BaggageCabin;
            flight.TotalSeats = dto.TotalSeats;
            flight.OwnerId = dto.OwnerId;

            await _flightService.UpdateFlightAsync(flight);
            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlight(int id)
        {
            await _flightService.DeleteFlightAsync(id);
            return NoContent();
        }

        //to approve a flight
        [Authorize(Roles = "Admin")]
        [HttpPatch("approve/{flightId}")]
        public async Task<IActionResult> ApproveFlight(int flightId)
        {
            await _flightService.ApproveFlightAsync(flightId);
            return Ok("Flight approved successfully.");
        }

    }
}
