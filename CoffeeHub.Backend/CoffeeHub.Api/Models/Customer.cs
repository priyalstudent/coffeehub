using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.Api.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string IdentityUserId { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
