using service_api.DTOs;
using service_api.Entities;
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

        public async Task<CustomerDTO?> GetById(Guid id)
        {
            var customer = await _repo.GetById(id);
            if (customer == null) return null;

            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task<CustomerDTO> Create(CustomerCreateDTO dto)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            await _repo.Create(customer);

            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task<CustomerDTO?> Update(Guid id, CustomerUpdateDTO dto)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return null;

            existing.Name = dto.Name;
            existing.Email = dto.Email;
            existing.PhoneNumber = dto.PhoneNumber;

            await _repo.Update(existing);

            return new CustomerDTO
            {
                Id = existing.Id,
                Name = existing.Name,
                Email = existing.Email,
                PhoneNumber = existing.PhoneNumber
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;

            await _repo.Delete(existing);
            return true;
        }
    }
}
