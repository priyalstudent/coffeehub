namespace CoffeeHub.Api.Contracts.Payments
{
    public class CreatePaymentRequest
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }

}
