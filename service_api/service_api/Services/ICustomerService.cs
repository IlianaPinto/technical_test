using service_api.DTOs;

namespace service_api.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO?> GetById(Guid id);
        Task<CustomerDTO> Create(CustomerCreateDTO dto);
        Task<CustomerDTO?> Update(Guid id, CustomerUpdateDTO dto);
        Task<bool> Delete(Guid id);
    }
}
