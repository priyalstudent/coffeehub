using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.Api.Contracts.Orders
{
    public class OrderRequestContract
    {
        [Required]
        [MinLength(1)]
        public List<OrderItemRequestContract> Items { get; set; } = new();
    }
}
