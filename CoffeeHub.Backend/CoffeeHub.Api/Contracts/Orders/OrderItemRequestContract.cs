using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.Api.Contracts.Orders
{
    public class OrderItemRequestContract
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
