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
                ImageUrl = product.ImageUrl
            };
        }

        public static Product ToModel(this ProductRequestContract request)
        {
            return new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            };
        }
    }
}
