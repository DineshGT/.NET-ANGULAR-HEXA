namespace SimplyFly.API.DAL.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RouteId { get; set; }
        public Routes Route { get; set; }

        public DateTime BookingDate { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }  // Confirmed, Cancelled

        public ICollection<Payment> Payments { get; set; }
    }
}
