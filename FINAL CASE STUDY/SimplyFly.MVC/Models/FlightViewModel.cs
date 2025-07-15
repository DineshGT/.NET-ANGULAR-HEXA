namespace SimplyFly.MVC.Models
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public string FlightNumber { get; set; }
        public string BaggageCheckIn { get; set; }
        public string BaggageCabin { get; set; }
        public bool IsApproved { get; set; }    
        public int TotalSeats { get; set; }
        public int OwnerId { get; set; }
    }
}
