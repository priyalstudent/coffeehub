using CoffeeHub.Api.Contracts.Products;
using CoffeeHub.Api.Mapping;
using CoffeeHub.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetProducts();
            return Ok(products.Select(p => p.ToResponse()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product.ToResponse());
        }

        [HttpPost]
        public IActionResult Create(ProductRequestContract request)
        {
            var product = request.ToModel();
            _productService.AddProduct(product);
            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product.ToResponse()
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductRequestContract request)
        {
            var updatedProduct = request.ToModel();
            var success = _productService.UpdateProduct(id, updatedProduct);

            if (!success)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _productService.DeleteProduct(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
