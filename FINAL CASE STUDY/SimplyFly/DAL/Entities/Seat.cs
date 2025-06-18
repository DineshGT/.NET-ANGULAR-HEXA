namespace SimplyFly.API.DAL.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public bool IsBooked { get; set; }

        public int RouteId { get; set; }
        public Routes Route { get; set; }
    }
}
