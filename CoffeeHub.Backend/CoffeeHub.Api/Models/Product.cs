using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeHub.Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public string? Image { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
