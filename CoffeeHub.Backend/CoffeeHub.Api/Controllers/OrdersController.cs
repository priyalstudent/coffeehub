using CoffeeHub.Api.Contracts.Orders;
using CoffeeHub.Api.Mapping;
using CoffeeHub.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            return Ok(orders.Select(o => o.ToResponse()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
                return NotFound();

            return Ok(order.ToResponse());
        }

        [HttpPost]
        public IActionResult Create(OrderRequestContract request)
        {
            var order = request.ToModel();
            var created = _orderService.Create(order);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created.ToResponse()
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderRequestContract request)
        {
            var order = request.ToModel();
            var success = _orderService.Update(id, order);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _orderService.Delete(id);

            if (!success)
                return NotFound();

            return NoContent();
        }

    }
}
