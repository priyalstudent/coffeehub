using CoffeeHub.Api.Models;
using CoffeeHub.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Api.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactMessagesController : ControllerBase
    {
        private readonly ContactMessageCosmosService _service;

        public ContactMessagesController(ContactMessageCosmosService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(ContactMessage msg)
        {
            await _service.AddAsync(msg);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}