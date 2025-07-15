using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;
using SimplyFly.API.DAL.Repositories;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repo;

        public PaymentService(IPaymentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync() => await _repo.GetAllAsync();

        public async Task<Payment?> GetPaymentByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Payment>> GetPaymentsByBookingIdAsync(int bookingId)
            => await _repo.GetByBookingIdAsync(bookingId);

        public async Task CreatePaymentAsync(Payment payment)
        {
            try
            {
                payment.PaymentDate = DateTime.Now;

                await _repo.AddAsync(payment);     
                await _repo.SaveChangesAsync();   
            }
            catch (Exception ex)
            {
                // Log it if needed
                throw new Exception($"Error creating payment: {ex.Message}", ex);
            }
        }

        public async Task<bool> RefundPaymentAsync(int paymentId)
        {
            var payment = await _repo.GetPaymentByIdAsync(paymentId);
            if (payment == null)
                return false;

            payment.IsRefunded = true;
            payment.PaymentStatus = "Refunded";
            await _repo.SaveChangesAsync();
            return true;
        }

    }
}
