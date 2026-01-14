using System.ComponentModel.DataAnnotations.Schema;


namespace CoffeeHub.Api.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
