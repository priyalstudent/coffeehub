using CoffeeHub.Api.Contracts.Products;
using CoffeeHub.Api.Models;

namespace CoffeeHub.Api.Mapping
{
    public static class ProductMapping
    {
        public static ProductResponseContract ToResponse(this Product product)
        {
            return new ProductResponseContract
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image
            };
        }

        public static Product ToModel(this ProductRequestContract request)
        {
            return new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Image = request.Image
            };
        }
    }
}
