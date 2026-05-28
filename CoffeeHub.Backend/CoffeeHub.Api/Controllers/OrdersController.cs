using CoffeeHub.Api.Contracts.Orders;
using CoffeeHub.Api.Mapping;
using CoffeeHub.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace CoffeeHub.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [Authorize]
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
            var userSub = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                       ?? User.FindFirst("sub")?.Value;

            if (userSub == null)
                return Unauthorized();

            var isAdmin = userSub == "0be1b595-6a44-43d2-89ab-bb6d8d4250fc";

            if (isAdmin)
            {
                var allOrders = _orderService.GetAll();
                return Ok(allOrders.Select(o => o.ToResponse()));
            }

            var orders = _orderService.GetOrdersByIdentitySub(userSub);
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
            var userSub = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                       ?? User.FindFirst("sub")?.Value;

            if (userSub == null)
                return Unauthorized("No user id in token");

            var order = request.ToModel();

            var customerId = _orderService.GetCustomerIdByIdentitySub(userSub, User);

            order.CustomerId = customerId;  

            var created = _orderService.Create(order);

            return CreatedAtAction(nameof(GetById),
                new { id = created.Id },
                created.ToResponse());
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
