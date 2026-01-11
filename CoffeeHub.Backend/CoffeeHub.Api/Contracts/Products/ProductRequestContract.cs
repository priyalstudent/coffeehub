using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.Api.Contracts.Products
{
    public class ProductRequestContract
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = "";

        [Required]
        public string ImageUrl { get; set; } = "";
    }
}
