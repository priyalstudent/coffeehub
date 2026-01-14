using System;
using System.Collections.Generic;

namespace CoffeeHub.Api.Contracts.Orders
{
    public class OrderResponseContract
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public List<OrderItemResponseContract> Items { get; set; } = new();
    }

    public class OrderItemResponseContract
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
