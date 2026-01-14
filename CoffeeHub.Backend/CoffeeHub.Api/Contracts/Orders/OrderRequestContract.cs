using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.Api.Contracts.Orders
{
    public class OrderRequestContract
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [MinLength(1)]
        public List<OrderItemRequestContract> Items { get; set; } = new();
    }
}
