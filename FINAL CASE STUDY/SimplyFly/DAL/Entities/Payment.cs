namespace SimplyFly.API.DAL.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // CreditCard, UPI, etc.
        public decimal AmountPaid { get; set; }
        public string TransactionId { get; set; }
    }
}
