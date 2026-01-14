using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.Api.Contracts.Customers
{
    public class CustomerResponseContract
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int OrdersCount { get; set; }
    }
}

