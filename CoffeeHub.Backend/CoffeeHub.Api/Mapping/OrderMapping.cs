using CoffeeHub.Api.Contracts.Orders;
using CoffeeHub.Api.Models;

namespace CoffeeHub.Api.Mapping
{
    public static class OrderMapping
    {
        public static OrderResponseContract ToResponse(this Order order)
        {
            return new OrderResponseContract
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.FirstName + " " + order.Customer.LastName,
                Items = order.OrderItems.Select(oi => new OrderItemResponseContract
                {
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };
        }

        public static Order ToModel(this OrderRequestContract request)
        {
            return new Order
            {
                OrderDate = DateTime.UtcNow,
                OrderItems = request.Items.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                }).ToList()
            };
        }

    }
}

