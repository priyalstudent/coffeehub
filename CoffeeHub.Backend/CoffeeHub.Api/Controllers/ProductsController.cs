using CoffeeHub.Api.Contracts.Products;
using CoffeeHub.Api.Contracts.Storage;
using CoffeeHub.Api.Mapping;
using CoffeeHub.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Api.Controllers
{
    //[Authorize]
    //[AllowAnonymous]
    [Authorize]
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IImageStorage _imageStorage;
        public ProductsController(ProductService productService, IImageStorage imageStorage)
        {
            _productService = productService;
            _imageStorage = imageStorage;
        }

        //anyone can browse
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? search)
        {
            var products = _productService.GetProducts(search);
            return Ok(products.Select(p => p.ToResponse()));
        }

        // anyone can view
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product.ToResponse());
        }

        //only admin
        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductRequestContract request)
        {
            var updatedProduct = request.ToModel();
            var success = _productService.UpdateProduct(id, updatedProduct);

            if (!success)
                return NotFound();

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _productService.DeleteProduct(id);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpPost("{id}/image")]
        public async Task<IActionResult> UploadProductImage(
            int id,
            IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var product = _productService.GetById(id);
            if (product == null)
                return NotFound();

            var fileName = $"product-{id}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var imageUrl = await _imageStorage.UploadAsync(
                file.OpenReadStream(),
                fileName,
                file.ContentType
            );

            product.Image = imageUrl;
            _productService.Update(product);

            return Ok(new { imageUrl });
        }

    }
}
