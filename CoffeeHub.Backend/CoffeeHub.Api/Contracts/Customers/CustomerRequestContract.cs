using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.Api.Contracts.Customers
{
    public class CustomerRequestContract
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}




