using CoffeeHub.Api.Data;
using CoffeeHub.Api.Models;

namespace CoffeeHub.Api.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
        public bool UpdateProduct(int id, Product updated)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return false;

            product.Name = updated.Name;
            product.Price = updated.Price;
            product.Image = updated.Image;
            product.Description = updated.Description;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
