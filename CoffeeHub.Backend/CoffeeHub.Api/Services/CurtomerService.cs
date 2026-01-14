using CoffeeHub.Api.Data;
using CoffeeHub.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Api.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers
                .Include(c => c.Orders)
                .ToList();
        }

        public Customer? GetById(int id)
        {
            return _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == id);
        }

        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public bool Update(int id, Customer updated)
        {
            var existing = _context.Customers.Find(id);
            if (existing == null) return false;

            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;
            existing.Email = updated.Email;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
