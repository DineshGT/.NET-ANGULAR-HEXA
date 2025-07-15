using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DTOs.Models.Payment;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllPayments()
        {
            return Ok(await _paymentService.GetAllPaymentsAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("booking/{bookingId}")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsByBooking(int bookingId)
        {
            return Ok(await _paymentService.GetPaymentsByBookingIdAsync(bookingId));
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentCreateDTO dto)
        {
            try
            {
                var payment = new Payment
                {
                    BookingId = dto.BookingId,
                    PaymentDate = dto.PaymentDate,
                    PaymentMethod = dto.PaymentMethod,
                    AmountPaid = dto.AmountPaid,
                    TransactionId = dto.TransactionId,
                    PaymentStatus = dto.PaymentStatus
                };

                await _paymentService.CreatePaymentAsync(payment);
                return CreatedAtAction(nameof(GetAllPayments), new { }, payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        // For amount refund..

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("refund/{paymentId}")]
        public async Task<IActionResult> RefundPayment(int paymentId)
        {
            var success = await _paymentService.RefundPaymentAsync(paymentId);
            if (!success)
                return NotFound("Payment not found.");

            return Ok("Payment marked as refunded.");
        }

        // to get all refunded amounts..

        [Authorize(Roles = "Admin, Owner")]
        [HttpGet("refunded")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetRefundedPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments.Where(p => p.IsRefunded));
        }

    }
}
