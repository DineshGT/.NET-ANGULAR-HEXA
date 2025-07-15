namespace SimplyFly.API.DTOs.Models.Seat
{
    public class SeatCreateDTO
    {
        public string SeatNumber { get; set; }
        public bool IsBooked { get; set; } = false;
        public int RouteId { get; set; }
    }
}
