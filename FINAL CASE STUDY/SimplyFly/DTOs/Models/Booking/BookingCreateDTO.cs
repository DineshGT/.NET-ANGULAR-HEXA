namespace SimplyFly.API.DTOs.Models.Booking
{
    public class BookingCreateDTO
    {
        public int UserId { get; set; }
        public int RouteId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
