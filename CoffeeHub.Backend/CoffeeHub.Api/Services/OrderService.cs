using CoffeeHub.Api.Data;
using CoffeeHub.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Api.Services
{
    public class OrderService
    {
        private readonly AppDbContext _db;

        public OrderService(AppDbContext db)
        {
            _db = db;
        }

        public Order Create(Order order)
        {
            foreach (var item in order.OrderItems)
            {
                var product = _db.Products.FirstOrDefault(p => p.Id == item.ProductId);

                if (product == null)
                    throw new InvalidOperationException($"Product {item.ProductId} not found");

                item.UnitPrice = product.Price;
            }

            order.TotalAmount = order.OrderItems
                .Sum(i => i.UnitPrice * i.Quantity);

            _db.Orders.Add(order);
            _db.SaveChanges();

            return _db.Orders
               .Include(o => o.Customer)
               .Include(o => o.OrderItems)
                   .ThenInclude(oi => oi.Product)
               .FirstOrDefault(o => o.Id == order.Id);
        }

        public List<Order> GetAll()
        {
            return _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToList();
        }

        public Order? GetById(int id)
        {
            return _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public bool Update(int id, Order updatedOrder)
        {
            var existingOrder = _db.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.Id == id);

            if (existingOrder == null)
                return false;

            _db.OrderItems.RemoveRange(existingOrder.OrderItems);

            existingOrder.OrderItems = updatedOrder.OrderItems;

            foreach (var item in existingOrder.OrderItems)
            {
                var product = _db.Products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product == null)
                    throw new InvalidOperationException($"Product {item.ProductId} not found");

                item.UnitPrice = product.Price;
            }

            existingOrder.TotalAmount = existingOrder.OrderItems
                .Sum(i => i.UnitPrice * i.Quantity);

            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var order = _db.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return false;

            _db.Orders.Remove(order);
            _db.SaveChanges();
            return true;
        }

    }
}
