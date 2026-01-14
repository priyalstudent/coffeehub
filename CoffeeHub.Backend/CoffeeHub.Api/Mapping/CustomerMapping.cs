using CoffeeHub.Api.Contracts.Customers;
using CoffeeHub.Api.Models;

namespace CoffeeHub.Api.Mapping
{
    public static class CustomerMapping
    {
        public static CustomerResponseContract ToResponse(this Customer customer)
        {
            return new CustomerResponseContract
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                OrdersCount = customer.Orders.Count
            };
        }

        public static Customer ToModel(this CustomerRequestContract request)
        {
            return new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }
    }
}
