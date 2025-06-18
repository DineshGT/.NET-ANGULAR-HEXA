namespace SimplyFly.API.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Role { get; set; }  // Passenger, FlightOwner, Admin
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
