using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using service_api.DTOs;
using service_api.Services;

namespace service_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService service, ILogger<OrderController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAll();
            _logger.LogInformation("Retrieved {Count} orders", orders.Count());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _service.GetById(id);
            if (order == null)
            {
                _logger.LogWarning("Order with ID {Id} not found", id);
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(OrderCreateDTO dto)
        {
            var created = await _service.Create(dto);
            _logger.LogInformation("Order created with ID {Id}", created.CustomerId);
            return CreatedAtAction(nameof(GetById), new { id = created.CustomerId }, created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, OrderUpdateDTO dto)
        {
            var updated = await _service.Update(id, dto);
            if (updated == null)
            {
                _logger.LogWarning("Attempt to update non existent order with ID {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Order with ID {Id} updated", id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted)
            {
                _logger.LogWarning("Attempt to delete non existent order with ID {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Order with ID {Id} deleted", id);
            return NoContent();
        }

        [HttpGet("summary/by-customer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrderSummaryByCustomer()
        {
            var summary = await _service.GetOrderSummary();
            _logger.LogInformation("Retrieved {count} order summary", summary.Count());
            return Ok(summary);
        }
    }
}
