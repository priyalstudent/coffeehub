using CoffeeHub.Api.Contracts.Customers;
using CoffeeHub.Api.Mapping;
using CoffeeHub.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers.Select(c => c.ToResponse()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer.ToResponse());
        }

        [HttpPost]
        public IActionResult Create(CustomerRequestContract request)
        {
            var customer = request.ToModel();
            var created = _customerService.Create(customer);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created.ToResponse()
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomerRequestContract request)
        {
            var updated = request.ToModel();
            var success = _customerService.Update(id, updated);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _customerService.Delete(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
