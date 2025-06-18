namespace SimplyFly.API.DAL.Entities
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public string FlightNumber { get; set; }
        public string BaggageCheckIn { get; set; }
        public string BaggageCabin { get; set; }
        public int TotalSeats { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Routes> Routes { get; set; }
    }
}
