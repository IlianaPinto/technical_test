using service_api.DTOs;
using service_api.Repository;

namespace service_api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var customer = await _repo.GetAll();
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
