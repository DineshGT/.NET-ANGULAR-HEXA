using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payment>> GetPaymentsByBookingIdAsync(int bookingId);
        Task CreatePaymentAsync(Payment payment);
        Task<bool> RefundPaymentAsync(int paymentId);
    }
}
