namespace SimplyFly.API.DTOs.Models.Route
{
    public class RouteCreateDTO
    {
        public int RouteId { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Fare { get; set; }
        public int FlightId { get; set; }
    }
}
