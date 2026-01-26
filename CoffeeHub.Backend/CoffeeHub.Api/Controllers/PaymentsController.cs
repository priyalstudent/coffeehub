using CoffeeHub.Api.Contracts.Payments;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CoffeeHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        [HttpPost("create-payment")]
        public IActionResult CreatePayment([FromBody] CreatePaymentRequest request)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(request.Amount * 100), // euros → cents
                Currency = "eur",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var intent = service.Create(options);

            return Ok(new { clientSecret = intent.ClientSecret });
        }
    }
}
