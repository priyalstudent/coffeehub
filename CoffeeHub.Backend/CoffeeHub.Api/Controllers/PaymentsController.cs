using CoffeeHub.Api.Contracts.Payments;
using CoffeeHub.Api.Data;
using CoffeeHub.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CoffeeHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;

        public PaymentsController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

            if (request.Amount <= 0)
                return BadRequest("Amount must be greater than zero");

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(request.Amount * 100),
                Currency = "eur",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var intent = service.Create(options);

            var payment = new Payment
            {
                Amount = request.Amount,
                Status = "Pending",
                StripePaymentIntentId = intent.Id
            };

            _db.Payments.Add(payment);
            await _db.SaveChangesAsync();

            return Ok(new { clientSecret = intent.ClientSecret });
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var secret = _configuration["Stripe:WebhookSecret"];

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    secret
                );

                if (stripeEvent.Type == "payment_intent.succeeded")
                {
                    var intent = stripeEvent.Data.Object as PaymentIntent;

                    var payment = _db.Payments.FirstOrDefault(p => p.StripePaymentIntentId == intent.Id);
                    if (payment != null)
                    {
                        payment.Status = "Succeeded";
                        await _db.SaveChangesAsync();
                    }
                }
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
