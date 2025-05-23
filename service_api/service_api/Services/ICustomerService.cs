using service_api.DTOs;

namespace service_api.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAll();
    }
}
