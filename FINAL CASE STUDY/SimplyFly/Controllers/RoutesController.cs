using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DTOs.Models.Route;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IRoutesService _routesService;

        public RoutesController(IRoutesService routesService)
        {
            _routesService = routesService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Routes>>> GetAllRoutes()
        {
            return Ok(await _routesService.GetAllRoutesAsync());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Routes>> GetRoute(int id)
        {
            var route = await _routesService.GetRouteByIdAsync(id);
            if (route == null) return NotFound();
            return Ok(route);
        }

        // ✈️ Search by origin/destination/date
        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Routes>>> SearchFlights(
    [FromQuery] string origin,
    [FromQuery] string destination,
    [FromQuery] DateTime date)
        {
            var routes = await _routesService.SearchRoutesAsync(origin, destination, date);
            return Ok(routes);
        }

        [Authorize(Roles = "Admin, Owner")]
        [HttpGet("flight/{flightId}")]
        public async Task<ActionResult<IEnumerable<Routes>>> GetRoutesByFlightId(int flightId)
        {
            return Ok(await _routesService.GetRoutesByFlightIdAsync(flightId));
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<ActionResult> CreateRoute([FromBody] RouteCreateDTO dto)
        {
            var route = new Routes
            {
                Origin = dto.Origin,
                Destination = dto.Destination,
                DepartureTime = dto.DepartureTime,
                ArrivalTime = dto.ArrivalTime,
                Fare = dto.Fare,
                FlightId = dto.FlightId
            };

            await _routesService.CreateRouteAsync(route);
            return CreatedAtAction(nameof(GetRoute), new { id = route.RouteId }, route);
        }

        [Authorize(Roles = "Admin, Owner")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoute(int id, [FromBody] RouteCreateDTO dto)
        {
            if (id != dto.RouteId)
                return BadRequest("Route ID mismatch");

            var success = await _routesService.UpdateRouteAsync(dto);
            if (!success)
                return NotFound("Route not found");

            return Ok("Route updated successfully.");
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoute(int id)
        {
            await _routesService.DeleteRouteAsync(id);
            return NoContent();
        }

        
    }
}
