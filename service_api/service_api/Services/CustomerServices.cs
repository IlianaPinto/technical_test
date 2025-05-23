using service_api.DTOs;
using service_api.Repository;

namespace service_api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository repo, ILogger<CustomerService> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var customer = await _repo.GetAll();

            _logger.LogInformation("Retrieved {customerCount} customers from the system", customer.Count());

            return customer.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber
            });
        }
    }
}
