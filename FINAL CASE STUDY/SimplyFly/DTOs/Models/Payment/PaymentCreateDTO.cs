namespace SimplyFly.API.DTOs.Models.Payment
{
    public class PaymentCreateDTO
    {
        public int BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal AmountPaid { get; set; }
        public string TransactionId { get; set; }
        public bool IsRefunded { get; set; } = false;
        public string PaymentStatus { get; set; } = "Success";


    }
}
