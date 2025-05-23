using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using service_api.DTOs;
using service_api.Services;

namespace service_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService service, ILogger<CustomerController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAll();
            _logger.LogInformation("Retrieved {Count} customers", customers.Count());
            return Ok(customers);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _service.GetById(id);
            if (customer == null)
            {
                _logger.LogWarning("Customer with ID {Id} not found", id);
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CustomerCreateDTO dto)
        {
            var created = await _service.Create(dto);
            _logger.LogInformation("Customer created with ID {Id}", created.Id);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CustomerUpdateDTO dto)
        {
            var updated = await _service.Update(id, dto);
            if (updated == null)
            {
                _logger.LogWarning("Attempt to update non-existent customer with ID {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Customer with ID {Id} updated", id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted)
            {
                _logger.LogWarning("Attempt to delete non-existent customer with ID {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Customer with ID {Id} deleted", id);
            return NoContent();
        }

    }
}
